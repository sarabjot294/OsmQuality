﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Logic
{
    /// <summary>
    /// public long Id { get; set; }
    /// public short? WayOff { get; set; }
    /// public short? RelOff { get; set; }
    /// public long[] Parts { get; set; }
    /// public string[] Members { get; set; }
    /// public string[] Tags { get; set; }
    /// </summary>
    public partial class PlanetOsmRel
    {
        public long Id { get; set; }
        public short? WayOff { get; set; }
        public short? RelOff { get; set; }
        public long[] Parts { get; set; }
        public string[] Members { get; set; }
        public string[] Tags { get; set; }
    }
}
