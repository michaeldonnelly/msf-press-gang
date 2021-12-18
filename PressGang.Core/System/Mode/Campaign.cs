using System;
using System.Collections.Generic;
using PressGang.Core.System.Location;

namespace PressGang.Core.System.Mode
{
    public class Campaign : GameMode
    {
        public Campaign(string name, int levels = 0) : base(name)
        {
            if (levels != 0)
            {
                Levels = levels;
                NodesPerLevel = 9;
            }
        }

        public int Levels { get; set; }

        public int NodesPerLevel { get; set; }

        public List<CampaignNode> Nodes()
        {
            List<CampaignNode> nodes = new();
            for (int level = 1; level <= Levels; level++)
            {
                for (int node = 1; node <= NodesPerLevel; node++)
                {
                    CampaignNode campaignNode = new(this, level, node);
                    nodes.Add(campaignNode);
                }
            }

            return nodes;
        }
    }
}
