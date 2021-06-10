using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.Models
{
    public partial class Country
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Db { get; set; }
        public long? Status { get; set; }
    }
}
