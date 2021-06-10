using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.RawModels
{
    public partial class IndoorPoint
    {
        public long OsmId { get; set; }
        public string OsmType { get; set; }
        public string Name { get; set; }
        public int? Layer { get; set; }
        public string Level { get; set; }
        public string Room { get; set; }
        public string Entrance { get; set; }
        public string Door { get; set; }
        public string Capacity { get; set; }
        public string Highway { get; set; }
    }
}
