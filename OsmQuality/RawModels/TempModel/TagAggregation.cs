using System;
using System.Collections.Generic;
using System.Text;

namespace OsmQuality.RawModels.TempModel
{
    public partial class TagAggregation
    {
        public string tag { get; set; }
        public long count { get; set; }
        public double percent{ get; set; }

    }
}
