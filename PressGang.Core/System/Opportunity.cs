using System;
namespace PressGang.Core.System
{
    public class Opportunity
    {
        public Opportunity()
        {
        }

        public Resource Resource { get; set; }

        public ResourceLocation ResourceLocation { get; set; }
    }
}
