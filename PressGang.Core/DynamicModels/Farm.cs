using System;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

namespace PressGang.Core.DynamicModels
{
    public class Farm
    {
        public Farm()
        {
        }

        public int Priority { get; set; }

        public Resource Resource { get; set; }

        public Opportunity Opportunity { get; set; }
    }
}
