﻿using System;

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

        public Resource Resource { get; set; }

        public Location Location { get; set; }

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