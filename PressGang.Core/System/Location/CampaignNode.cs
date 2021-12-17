using System;
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
    }
}
