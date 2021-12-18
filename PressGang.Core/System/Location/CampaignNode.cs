﻿using System;
using PressGang.Core.System.Mode;

namespace PressGang.Core.System.Location
{
    public class CampaignNode : ResourceLocation
    {
        public CampaignNode(string name) : base(name)
        {
        }

        public Campaign Campaign { get; set; }

        public int Level { get; set; }

        public int Node { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}-{2}", Campaign.Name, Level.ToString(), Node.ToString());
        }
    }
}
