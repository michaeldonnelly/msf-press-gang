using System;
using System.Collections.Generic;
using PressGang.Core.StaticModels;

namespace PressGang.Core.DynamicModels
{
    public class FarmLand
    {
        public FarmLand()
        {
        }

        public LocationType LocationType { get; set; }

        public List<Farm> Farms { get; set; }
       
    }
}
