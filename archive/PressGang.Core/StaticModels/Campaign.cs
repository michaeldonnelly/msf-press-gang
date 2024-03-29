﻿using System;
using System.Collections.Generic;

namespace PressGang.Core.StaticModels
{
    public class Campaign 
    {
        public Campaign(string name, int levels = 0) 
        {
            Name = name;
            if (levels != 0)
            {
                Levels = levels;
                NodesPerLevel = 9;
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

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

        public override string ToString()
        {
            return Name;
        }
    }
}
