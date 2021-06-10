using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.RawModels
{
    public partial class InfrastructurePoint
    {
        public long OsmId { get; set; }
        public string OsmType { get; set; }
        public string OsmSubtype { get; set; }
        public string Name { get; set; }
        public int? Ele { get; set; }
        public decimal? Height { get; set; }
        public string Operator { get; set; }
        public string Material { get; set; }
    }
}
