using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.RawModels
{
    public partial class WaterLine
    {
        public long OsmId { get; set; }
        public string OsmType { get; set; }
        public string OsmSubtype { get; set; }
        public string Name { get; set; }
        public int Layer { get; set; }
        public string Tunnel { get; set; }
        public string Bridge { get; set; }
        public string Boat { get; set; }
    }
}
