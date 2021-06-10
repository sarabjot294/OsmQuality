using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.RawModels
{
    public partial class Tag
    {
        public char GeomType { get; set; }
        public long OsmId { get; set; }
        public string Tags { get; set; }
    }
}
