using System;
using System.Collections.Generic;

#nullable disable

namespace Logic
{
    /// <summary>
    /// A Node is made of: 
    /// public long Id { get; set; }
    /// public int Lat { get; set; }
    /// public int Lon { get; set; }
    /// </summary>
    public partial class PlanetOsmNode
    {
        public long Id { get; set; }
        public int Lat { get; set; }
        public int Lon { get; set; }

        public override bool Equals(object obj)
        {
            return obj is PlanetOsmNode node &&
                   Id == node.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
