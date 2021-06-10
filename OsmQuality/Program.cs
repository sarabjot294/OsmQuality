using Microsoft.EntityFrameworkCore;
using OsmQuality.api;
using OsmQuality.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
           
            DbTransactions.checkDbRawQuery();
            //API(nodes);
            //Console.WriteLine("Total ways : " + ways[0].Tags[0]);

            //Console.WriteLine("Total Nodes: " + nodes.Count);
            //Console.WriteLine("Total Ways: " + ways.Count);
        }

        //public void API(List<PlanetOsmNode> nodes)
        //{
        //    OsmApiClient osmApiClient = new OsmApiClient();
        //    Dictionary<long, List<NodeHistory>> nodeHistories = new Dictionary<long, List<NodeHistory>>();
        //    for (int i = 0; i < 100; i++)
        //    {
        //        nodeHistories.Add(nodes[i].Id, osmApiClient.ReadAPI("node", nodes[i].Id.ToString()));
        //        Console.WriteLine(i + " request completed total history for the node " + nodes[i].ToString() + " is " + nodeHistories.GetValueOrDefault(nodes[i].Id).Count);
        //    }
        //}

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
