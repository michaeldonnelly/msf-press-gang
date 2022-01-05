using System;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

namespace PressGang.Core.DynamicModels
{
    public class Farm
    {
        public Farm(int priority, Resource resource, Opportunity opportunity)
        {
            Priority = priority;
            Resource = resource;
            Opportunity = opportunity;
        }

        public int Priority { get; set; }

        public Resource Resource { get; set; }

        public Opportunity Opportunity { get; set; }
    }
}
