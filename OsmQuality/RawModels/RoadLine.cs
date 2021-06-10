using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.RawModels
{
    public partial class RoadLine
    {
        public long OsmId { get; set; }
        public string OsmType { get; set; }
        public string Name { get; set; }
        public string Ref { get; set; }
        public int? Maxspeed { get; set; }
        public short? Oneway { get; set; }
        public int Layer { get; set; }
        public string Tunnel { get; set; }
        public string Bridge { get; set; }
        public bool Major { get; set; }
        public bool? RouteFoot { get; set; }
        public bool? RouteCycle { get; set; }
        public bool? RouteMotor { get; set; }
    }
}
