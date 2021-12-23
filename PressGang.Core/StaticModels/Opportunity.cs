using System;

namespace PressGang.Core.StaticModels
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

        public int ResourceId { get; set; }

        public virtual Resource Resource { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public override string ToString()
        {
            string name = Resource.Name;
            string location = Location.Name;
            if (Location.LocationType == LocationType.Store)
            {
                location += " Store";
            }
            return name + " at " + location;
        }
    }
}
