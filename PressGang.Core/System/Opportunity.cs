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
            Location = resourceLocation;
        }

        public int Id { get; set; }

        public Resource Resource { get; set; }

        public Location Location { get; set; }

        public override string ToString()
        {
            string name = Resource.Name;
            string location = Location.Name;
            return name + " at " + location;
        }
    }
}
