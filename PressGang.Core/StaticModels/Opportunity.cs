using System;

namespace PressGang.Core.StaticModels
{
    public class Opportunity
    {
        public Opportunity()
        {
        }

        public Opportunity(Resource resource, Location location)
        {
            Resource = resource;
            Location = location;
            Name = resource.Name + " at " + location.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int ResourceId { get; set; }

        public virtual Resource Resource { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
