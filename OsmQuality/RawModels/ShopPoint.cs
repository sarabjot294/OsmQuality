using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.RawModels
{
    public partial class ShopPoint
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
        public string Phone { get; set; }
        public bool? Wheelchair { get; set; }
        public string Operator { get; set; }
        public string Brand { get; set; }
        public string Website { get; set; }
    }
}
