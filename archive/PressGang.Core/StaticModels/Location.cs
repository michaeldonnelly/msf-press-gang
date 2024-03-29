﻿using System;

namespace PressGang.Core.StaticModels
{
    public class Location
    {
        public Location()
        {
        }

        public Location(string name)
        {
            Name = name;
        }

        public Location(Campaign campaign, int level, int node)
        {
            Name = CampaignNodeToString(campaign.Name, level, node);
            Campaign = campaign;
            Level = level;
            Node = node;
            LocationType = LocationType.CampaignNode;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public LocationType LocationType { get; set; }

        public Campaign Campaign { get; set; }

        public int Level { get; set; }

        public int Node { get; set; }

        private static string CampaignNodeToString(string campaignName, int level, int node)
        {
            return String.Format("{0} {1}-{2}", campaignName, level.ToString(), node.ToString());
        }

        public override string ToString()
        {
            string name = Name;
            if (LocationType == LocationType.Store)
            {
                name += " Store";
            }
            return name;
        }

    }

    public enum LocationType
    {
        CampaignNode,
        Store
    }
}
