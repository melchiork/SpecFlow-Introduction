using System;
using System.Collections.Generic;

namespace SpecFlowCore.Api
{
    public class Location
    {
        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public static int Revision { get; set; } = 1;

        public static List<Location> Locations { get; set; } = new List<Location>();
    }
}