using System;
using PressGang.Core.System.Location;

namespace PressGang.Core.System
{
    public class Opportunity
    {
        public Opportunity()
        {
        }

        public Opportunity(Resource resource, ResourceLocation resourceLocation)
        {
            Resource = resource;
            ResourceLocation = resourceLocation;
        }

        public int Id { get; set; }

        public Resource Resource { get; set; }

        public ResourceLocation ResourceLocation { get; set; }

        public override string ToString()
        {
            string name = Resource.Name;
            string location = ResourceLocation.ToString();
            return name + " at " + location;
        }
    }
}
