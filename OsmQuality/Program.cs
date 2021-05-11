using Logic;
using OsmQuality.api;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace OsmQuality
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            String dbName = "geo_ve_check";
            List<PlanetOsmWay> ways = new List<PlanetOsmWay>();
            List<PlanetOsmNode> nodes = new List<PlanetOsmNode>();
            using (CountryDbContext db = new CountryDbContext(dbName))
            {
                // Must convert to a list: https://stackoverflow.com/questions/61052687/a-command-is-already-in-progress/61054398
                // Load into memory.
                ways = db.PlanetOsmWays.ToList<PlanetOsmWay>();
                nodes = db.PlanetOsmNodes.ToList<PlanetOsmNode>();

            }
            OsmApiClient osmApiClient = new OsmApiClient();
            Dictionary<long, List<NodeHistory>> nodeHistories = new Dictionary<long, List<NodeHistory>>();
            for (int i = 0; i < 100; i++)
            {
                nodeHistories.Add(nodes[i].Id, osmApiClient.ReadAPI("node", nodes[i].Id.ToString()));
                Console.WriteLine(i + " request completed total history for the node " + nodes[i].ToString() + " is "  + nodeHistories.GetValueOrDefault(nodes[i].Id).Count);
            }

            Console.WriteLine("Total Nodes: " + nodes.Count);
            Console.WriteLine("Total Ways: " + ways.Count);
        }


        public void parseAPI()
        {
            
            
            var url = "http://localhost:58080/api/products";


           /* using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    XDocument xdoc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);

                    StringReader sr = new StringReader(xdoc.ToString());

                    DataSet ds = new DataSet();

                    ds.ReadXml(sr);

                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }

            }*/
        }


    }
}
