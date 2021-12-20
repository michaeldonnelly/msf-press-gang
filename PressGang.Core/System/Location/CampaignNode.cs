using System;
using PressGang.Core.System.Mode;

namespace PressGang.Core.System.Location
{
    public class CampaignNode : ResourceLocation
    {
        public CampaignNode(string name) : base(name, typeof(CampaignNode))
        {
        }

        public CampaignNode(Campaign campaign, int level, int node) : base(NodeToString(campaign.Name, level, node), typeof(CampaignNode))
        {
            Campaign = campaign;
            Level = level;
            Node = node;
        }

        public Campaign Campaign { get; set; }

        public int Level { get; set; }

        public int Node { get; set; }

        public override string ToString()
        {
            return NodeToString(Campaign.Name, Level, Node);
        }

        private static string NodeToString(string campaignName, int level, int node)
        { 
            return String.Format("{0} {1}-{2}", campaignName, level.ToString(), node.ToString());
        }
    }
}
