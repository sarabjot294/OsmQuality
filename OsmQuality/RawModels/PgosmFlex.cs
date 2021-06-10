using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.RawModels
{
    public partial class PgosmFlex
    {
        public DateTime OsmDate { get; set; }
        public bool DefaultDate { get; set; }
        public string Region { get; set; }
        public string PgosmFlexVersion { get; set; }
        public string Srid { get; set; }
        public string ProjectUrl { get; set; }
        public string Osm2pgsqlVersion { get; set; }
    }
}
