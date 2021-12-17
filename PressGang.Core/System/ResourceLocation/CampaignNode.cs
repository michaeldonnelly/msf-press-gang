using System;
using PressGang.Core.System.GameMode;

namespace PressGang.Core.System
{
    public class CampaignNode : ResourceLocation
    {
        public CampaignNode(string name) : base(name)
        {
        }

        public Campaign Campaign { get; set; }
    }
}
