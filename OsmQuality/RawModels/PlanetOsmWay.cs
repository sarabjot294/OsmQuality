using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.RawModels
{
    public partial class PlanetOsmWay
    {
        public long Id { get; set; }
        public long[] Nodes { get; set; }
        public string[] Tags { get; set; }
    }
}
