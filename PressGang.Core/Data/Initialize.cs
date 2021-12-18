using System;
using PressGang.Core.System;
using PressGang.Core.System.Location;
using PressGang.Core.System.Mode;


namespace PressGang.Core.Data
{
    public static class Initialize
    {
        public static string System()
        {
            new Store("Main");
            new Store("Raid");
            new Store("Blitz");
            new Store("Arena");
            new Store("War");

            new Campaign("Heros Assemble");
            new Campaign("Villains United");
            new Campaign("Nexus");
            var mystic = new Campaign("Mystic Forces Rising");

            CampaignNode mystic1n9 = new CampaignNode("mystic1n9")
            {
                Campaign = mystic,
                Level = 1,
                Node = 9
            };


            var cable = new Character("Cable");
            var cableShard = new CharacterShard(cable);
            var foo = new Opportunity()
            {
                Resource = cableShard,
                ResourceLocation = mystic1n9
            };

            return foo.ToString();
        }

    }
}
