using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsmQuality.api
{
    class NodeHistory
    {
        public long id { get; set; }
        public bool visible { get; set; }
        public int version { get; set; }
        public long changeset { get; set; }
        public DateTime timestamp { get; set; }
        public String user { get; set; }
        public long userId { get; set; }
        public GeoCoordinate geoCoordinate { get; set; }
        public Dictionary<String, String> tags { get; set; }
    }
}
