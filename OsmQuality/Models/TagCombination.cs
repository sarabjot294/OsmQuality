using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.Models
{
    public partial class TagCombination
    {
        public long Id { get; set; }
        public long TagId { get; set; }
        public long CountryId { get; set; }
        public long? TagCount { get; set; }
        public double? AverageCorrosTags { get; set; }
        public string[] TopTags { get; set; }
    }
}
