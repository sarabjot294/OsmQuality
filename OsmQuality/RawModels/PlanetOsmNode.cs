using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.RawModels
{
    public partial class PlanetOsmNode
    {
        public long Id { get; set; }
        public int Lat { get; set; }
        public int Lon { get; set; }
    }
}
