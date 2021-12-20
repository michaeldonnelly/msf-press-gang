using System;
using System.Collections.Generic;

namespace PressGang.Core.System
{
    public class Campaign 
    {
        public Campaign(string name, int levels = 0) 
        {
            if (levels != 0)
            {
                Levels = levels;
                NodesPerLevel = 9;
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Levels { get; set; }

        public int NodesPerLevel { get; set; }

        public List<Location> Nodes()
        {
            List<Location> nodes = new();
            for (int level = 1; level <= Levels; level++)
            {
                for (int node = 1; node <= NodesPerLevel; node++)
                {
                    Location campaignNode = new(this, level, node);
                    nodes.Add(campaignNode);
                }
            }

            return nodes;
        }
    }
}
