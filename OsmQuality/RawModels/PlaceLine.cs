using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.RawModels
{
    public partial class PlaceLine
    {
        public long OsmId { get; set; }
        public string OsmType { get; set; }
        public string Boundary { get; set; }
        public int? AdminLevel { get; set; }
        public string Name { get; set; }
    }
}
