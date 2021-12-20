using System;

namespace PressGang.Core.System
{
    public class Opportunity
    {
        public Opportunity()
        {
        }

        public Opportunity(Resource resource, Location resourceLocation)
        {
            Resource = resource;
            ResourceLocation = resourceLocation;
        }

        public int Id { get; set; }

        public Resource Resource { get; set; }

        public Location ResourceLocation { get; set; }

        public override string ToString()
        {
            string name = Resource.Name;
            string location = ResourceLocation.ToString();
            return name + " at " + location;
        }
    }
}
