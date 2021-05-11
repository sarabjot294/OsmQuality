using System;
using System.Collections.Generic;

#nullable disable

namespace Logic
{
    public partial class PlanetOsmWay
    {
        public long Id { get; set; }
        public long[] Nodes { get; set; }
        public string[] Tags { get; set; }

        public override bool Equals(object obj)
        {
            return obj is PlanetOsmWay way &&
                   Id == way.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
