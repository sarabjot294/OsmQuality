using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.Models
{
    public partial class TagCombinationDetail
    {
        public long Id { get; set; }
        public long? TcId { get; set; }
        public string TagKey { get; set; }
        public long? Count { get; set; }
        public double? Percent { get; set; }
    }
}
