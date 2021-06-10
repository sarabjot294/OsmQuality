using System;
using System.Collections.Generic;

#nullable disable

namespace OsmQuality.Models
{
    public partial class TagsKeyValue
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Category { get; set; }
        public string[] IdealTags { get; set; }
    }
}
