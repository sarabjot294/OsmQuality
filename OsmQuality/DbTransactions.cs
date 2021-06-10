using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OsmQuality.Models;
using OsmQuality.RawModels;
using OsmQuality.RawModels.TempModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OsmQuality.db
{
    static class DbTransactions
    {
        static long _TagThreshold = 5;
     
        static public void checkDbRawQuery()
        {
            cleanDatabase();
            String tag_counts = "";
            long TC_ID = 1;
            long TCD_ID = 1;
            List<Country> countries = getAllCountriesFromDB();

            foreach (Country country in countries)
            {
                Console.WriteLine("COUNTRY : " + country.Name);
                List<TagsKeyValue> tagsList = getAllTagsFromDB();
                Console.WriteLine("Length of tags " + tagsList.Count);
                foreach (TagsKeyValue tag in tagsList)
                {
                    String tag_key = tag.Key;
                    String tag_value = tag.Value;
                    Console.WriteLine("Key : " + tag_key + " and Value: " + tag_value);
                    long tagTotalCount = getTagCount(country.Db, tag_key, tag_value);
                    if (tagTotalCount == -1)
                    {
                        Console.WriteLine("ERROR. ABORT");
                        //Break, there is something wrong.
                    }
                    tag_counts = tagTotalCount.ToString();
                    List<TagAggregation> listOfTags = getAllTagsRespectively(country.Db, tag_key, tag_value, tag_counts);
                    Console.WriteLine("List Size " + listOfTags.Count);
                    
                    Double average = getAverageNumberOfTags(country.Db, tag_key, tag_value);
                    List<String> topNtags = new List<string>();
                    int temp = 0;
                    foreach (TagAggregation tagAggregation in listOfTags)
                    {
                        topNtags.Add(tagAggregation.tag);
                    }
                    
                    TagCombination tagCombination = createTctDataToInsert(TC_ID, tag.Id, country.Id, tagTotalCount, average, topNtags.ToArray());
                    insertTagCombinationData(tagCombination);
                    foreach (TagAggregation tags in listOfTags)
                    {
                        TagCombinationDetail tagCombinationDetail = createTcdtDataToInsert(TCD_ID, TC_ID, tags.tag, tags.count, Math.Round(tags.percent, 2));
                        insertTagCombinationDetailData(tagCombinationDetail);
                        TCD_ID++;
                    }
                    TC_ID++;
                }
            }
        }


        //Get All countries from DB, like Sri Lankya, paraguay, etc.
        static public List<Country> getAllCountriesFromDB()
        {
            String get_all_countries = @"select * from country where status=1";
            List<Country> CountryList = new List<Country>();
            using (tag_qualityContext db = new tag_qualityContext())
            {
                CountryList = db.Countries
                .FromSqlRaw(get_all_countries)
                .ToList();
            }
            return CountryList;
        }
        //Get All tags from DB, like amenity=cafe, amenity=fast_food, etc.
        static public List<TagsKeyValue> getAllTagsFromDB()
        {
            String get_all_tags = @"select * from tags_key_value";
            List<TagsKeyValue> tagsList = new List<TagsKeyValue>();
            using (tag_qualityContext db = new tag_qualityContext())
            {
                tagsList = db.TagsKeyValues
                .FromSqlRaw(get_all_tags)
                .ToList();
            }
            return tagsList;
        }

        //Get total count of a tag. Example for amenity=cafe, get the count of those tags
        static public long getTagCount(String country, String key, String value)
        {
            String get_tag_count = @"select count(t.osm_id) as tagnumbers, 0 as occurances
	                                    from osm.tags as t  
	                                    where t.tags ->> '" + key + "' = '" + value + "'";

            using (country_qualityContext db = new country_qualityContext(country))
            {
                long count = -1;
                var tag_count = db.AverageTags
                .FromSqlRaw(get_tag_count)
                .ToList();

                foreach (var first in tag_count)
                {
                    Console.WriteLine("Count : " + first.tagnumbers);
                    count = first.tagnumbers;
                }
                return count;
            }
        }

        //Getting the top '5' tags we need to compare it with different regions
        static public List<TagAggregation> getAllTagsRespectively(String country, String key, String value, String totalCount)
        {
            String query_get_top_tags = @"WITH
                                        unrolled_tags AS (
                                            SELECT
                                                t.osm_id,
                                                tags,
                                                UNNEST(k.keys) AS key
                                            FROM
                                                osm.tags t
                                                    LEFT JOIN LATERAL (SELECT
                                                                            ARRAY(SELECT *
                                                                                    FROM JSONB_OBJECT_KEYS(t.tags)) AS keys) k
                                                                ON TRUE
                                        )
                                    SELECT
                                            key as tag,
                                            COUNT(1) as count,    
                                            (cast(COUNT(1) as float)/cast(" + totalCount + @" as float))*100 as percent
                                    FROM unrolled_tags
                                    WHERE
                                        tags ->> '" + key + "' = '" + value + @"'
                                    GROUP BY
                                        key
                                    ORDER BY
                                            2 DESC";
            List<TagAggregation> tagList = new List<TagAggregation>();
            using (country_qualityContext db = new country_qualityContext(country))
            {
                var top_tags = db.TagAggregation
                    .FromSqlRaw(query_get_top_tags)
                    .ToList();

                int i = 0;
                foreach (var tag in top_tags)
                {
                    tagList.Add(tag);
                    //if (i > 0 && i <= _TagThreshold)
                    //{
                    //    tagList.Add(tag);
                    //}
                    //i++;
                }
            }
            return tagList;
        }

        //Getting Average Tag Number Ex: 4.6 other tags for 
        static public double getAverageNumberOfTags(String country, String key, String value)
        {
            String query_get_tag_count_for_particular_tag = @"select num as tagnumbers, count(num) as occurances
                                                from (
		                                                WITH
    	                                                unrolled_tags as
    	                                                (
    	                                                SELECT
                                                            t.osm_id,
                                                            tags,
                                                            UNNEST(k.keys) AS key
                                                        FROM
                                                            osm.tags t
                                                                LEFT JOIN LATERAL (SELECT
                                                                                       ARRAY(SELECT *
                                                                                             FROM JSONB_OBJECT_KEYS(t.tags)) AS keys) k
                                                                          ON true
                                                                          )
                                                    select
		                                                osm_id as id, count(1) as num
		                                                FROM unrolled_tags
		                                                where tags ->> '" + key + @"' = '" + value + @"' 
                                                        group by osm_id
                                                        order by count(1) desc
	                                                )
                                                as summation
                                                group by num
                                                order by count(1) desc";
            Double average = -1;
            using (country_qualityContext db = new country_qualityContext(country))
            {
                var tagCount = db.AverageTags
                    .FromSqlRaw(query_get_tag_count_for_particular_tag)
                    .ToList();

                long KeyValueSum = 0;
                long valueSum = 0;
                foreach (var count in tagCount)
                {
                    KeyValueSum += (count.tagnumbers * count.occurances);
                    valueSum += count.occurances;
                }
                average = (double)KeyValueSum / (double)valueSum;
                Console.WriteLine("The average tag count for " + country + " is " + Math.Round(average, 2));

            }
            return Math.Round(average,2);
        }

        static private TagCombination createTctDataToInsert(long id, long tagId, long countryId, long tagCount, double average, String[] topNtags)
        {
            TagCombination tagCombination = new TagCombination();
            tagCombination.Id = id;
            tagCombination.TagId = tagId;
            tagCombination.CountryId = countryId;
            tagCombination.TagCount = tagCount;
            tagCombination.AverageCorrosTags = average;
            tagCombination.TopTags= topNtags;
            return tagCombination;
        }

        static private TagCombinationDetail createTcdtDataToInsert(long id, long tcId, String tagName, long tagCount, double percent)
        {
            TagCombinationDetail tagCombinationDetail = new TagCombinationDetail();
            tagCombinationDetail.Id = id;
            tagCombinationDetail.TcId= tcId;
            tagCombinationDetail.TagKey = tagName;
            tagCombinationDetail.Count = tagCount;
            tagCombinationDetail.Percent= percent;
            return tagCombinationDetail;
        }
        static private void insertTagCombinationData(TagCombination tagCombination)
        {

            using (tag_qualityContext db = new tag_qualityContext())
            {
                db.Set<TagCombination>().Add(tagCombination);
                
                try
                {
                    int records = db.SaveChanges();
                    Console.WriteLine("Saved {0} Tag Combination to DB", records);
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine(e.InnerException);
                }
            }
             
        }
        static private void insertTagCombinationDetailData(TagCombinationDetail tagCombinationDetail)
        {

            using (tag_qualityContext db = new tag_qualityContext())
            {
                db.Set<TagCombinationDetail>().Add(tagCombinationDetail);

                try
                {
                    int records = db.SaveChanges();
                    //Console.WriteLine("Saved {0} Tag Combination Detials to DB", records);
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine(e.InnerException);
                }
            }

        }

        static private void cleanDatabase()
        {
            using (tag_qualityContext db = new tag_qualityContext())
            {

                db.Database.ExecuteSqlRaw("DROP TABLE IF EXISTS tag_combinations");
                db.Database.ExecuteSqlRaw("DROP TABLE IF EXISTS tag_combination_details");
                db.Database.ExecuteSqlRaw(@"CREATE TABLE public.tag_combinations
                    (
                        id bigint NOT NULL,
                        tag_id bigint NOT NULL,
                        country_id bigint NOT NULL,
                        tag_count bigint,
                        average_corros_tags double precision,
                        top_tags text[] COLLATE pg_catalog.""default"",
                        CONSTRAINT tag_combinations_pkey PRIMARY KEY (id)
                    )");

                db.Database.ExecuteSqlRaw(@"CREATE TABLE public.tag_combination_details
                    (
                        id bigint NOT NULL,
                        tc_id bigint,
                        tag_key text COLLATE pg_catalog.""default"",
                        count bigint,
                        percent double precision,
                        CONSTRAINT tag_combination_details_pkey PRIMARY KEY(id)
                    )
                    ");
            }
        }

    }
}
