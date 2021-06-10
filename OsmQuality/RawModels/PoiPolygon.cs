﻿using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.RawModels
{
    public partial class PoiPolygon
    {
        public long OsmId { get; set; }
        public string OsmType { get; set; }
        public string OsmSubtype { get; set; }
        public string Name { get; set; }
        public string Housenumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Address { get; set; }
        public string Operator { get; set; }
        public string MemberIds { get; set; }
    }
}
