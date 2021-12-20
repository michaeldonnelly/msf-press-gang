using System;
using PressGang.Core.System.Mode;

namespace PressGang.Core.System
{
    public class ResourceLocation
    {
        public ResourceLocation(string name)
        {
            Name = name;
        }

        public ResourceLocation(Campaign campaign, int level, int node)
        {
            Name = CampaignNodeToString(campaign.Name, level, node);
            Campaign = campaign;
            Level = level;
            Node = node;
        }


        public int Id { get; set; }

        public string Name { get; set; }

        public Campaign Campaign { get; set; }

        public int Level { get; set; }

        public int Node { get; set; }

        private static string CampaignNodeToString(string campaignName, int level, int node)
        {
            return String.Format("{0} {1}-{2}", campaignName, level.ToString(), node.ToString());
        }

    }
}
