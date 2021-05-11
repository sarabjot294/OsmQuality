using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Xml;

namespace OsmQuality.api
{
    class OsmApiClient : HttpClient
    {
        private string _baseUri = "https://www.openstreetmap.org/api/0.6/";
        public OsmApiClient()
        {

        }

        public List<NodeHistory> ReadAPI(String type, String id)
        {
            XmlTextReader reader = new XmlTextReader(_baseUri+type+"/"+id+"/"+"history");
            List<NodeHistory> nodeHistoryList = new List<NodeHistory>();
            NodeHistory nodeHistory = new NodeHistory();
            Dictionary<String, String> tags = new Dictionary<String, String>();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        if (reader.Name == "osm")
                            continue;
                        //Console.Write("Element: <" + reader.Name);
                        if (reader.Name == "node")
                        {
                            //When there are no attributes in the node Example https://www.openstreetmap.org/api/0.6/node/330047564/history
                            if (nodeHistory.tags == null)
                            {
                                nodeHistory.tags = tags;
                                nodeHistoryList.Add(nodeHistory);
                                //Console.WriteLine("No tags found\n");
                            }

                            nodeHistory = new NodeHistory();
                            tags = new Dictionary<String, String>();
                            while (reader.MoveToNextAttribute()) // Read the attributes.
                            {
                                if (reader.Name == "id")
                                    nodeHistory.id = long.Parse(reader.Value);
                                else if (reader.Name == "visible")
                                    nodeHistory.visible = bool.Parse(reader.Value);
                                else if (reader.Name == "version")
                                    nodeHistory.version= int.Parse(reader.Value);
                                else if (reader.Name == "changeset")
                                    nodeHistory.changeset = long.Parse(reader.Value);
                                else if (reader.Name == "timestamp")
                                    nodeHistory.timestamp = DateTime.Parse(reader.Value);
                                else if (reader.Name == "user")
                                    nodeHistory.user= reader.Value;
                                else if (reader.Name == "uid")
                                    nodeHistory.userId = long.Parse(reader.Value);
                                else if (reader.Name == "lat")
                                    nodeHistory.geoCoordinate = new Nest.GeoCoordinate(double.Parse(reader.Value), 0.0);
                                else if (reader.Name == "lon")
                                    nodeHistory.geoCoordinate = new Nest.GeoCoordinate(nodeHistory.geoCoordinate.Latitude, double.Parse(reader.Value));
                            }
                            //Console.WriteLine("Node ID version : " + nodeHistory.version);

                        }
                        if (reader.Name == "tag")
                        {
                            String key="", value = "";
                            while (reader.MoveToNextAttribute()) // Read the attributes.
                            {
                                if (reader.Name== "k")
                                    key = reader.Value;
                                else if (reader.Name== "v")
                                    value = reader.Value;
                            }
                            tags[key] = value;

                        }
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        //When there are attributes in the node https://www.openstreetmap.org/api/0.6/node/708866092/history
                        if (reader.Name == "node")
                        {
                            //Console.WriteLine("Total tags added: " + tags.Count + "\n");
                            nodeHistory.tags = tags;
                            nodeHistoryList.Add(nodeHistory);
                            tags = new Dictionary<String, String>();
                        }
                        break;
                }
            }
            return nodeHistoryList;
        }

    }
}
