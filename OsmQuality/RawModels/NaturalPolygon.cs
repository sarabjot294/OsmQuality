﻿using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.RawModels
{
    public partial class NaturalPolygon
    {
        public long OsmId { get; set; }
        public string OsmType { get; set; }
        public string Name { get; set; }
        public int? Ele { get; set; }
    }
}