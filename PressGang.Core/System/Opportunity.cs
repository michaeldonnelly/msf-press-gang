using System;
using PressGang.Core.System.Location;

namespace PressGang.Core.System
{
    public class Opportunity
    {
        public Opportunity()
        {
        }

        public Resource Resource { get; set; }

        public ResourceLocation ResourceLocation { get; set; }

        public override string ToString()
        {
            return Resource.Name + " at " + ResourceLocation.Name;
        }
    }
}
