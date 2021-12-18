using System;
using System.Collections.Generic;
using PressGang.Core.System;
using PressGang.Core.System.Location;
using PressGang.Core.System.Mode;
using PressGang.Core.User;

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

            Campaign heroes = new Campaign("Heros Assemble");
            new Campaign("Villains United");
            new Campaign("Nexus");
            Campaign mystic = new Campaign("Mystic Forces Rising");

            CampaignNode mystic1n9 = new CampaignNode("mystic1n9")
            {
                Campaign = mystic,
                Level = 1,
                Node = 9
            };

            CampaignNode heroes2n6 = new CampaignNode("heroes2n6")
            {
                Campaign = heroes,
                Level = 2,
                Node = 6
            };

            CampaignNode heroes6n9 = new CampaignNode("heroes6n9")
            {
                Campaign = heroes,
                Level = 6,
                Node = 9
            };


            Character cable = new Character("Cable");
            CharacterShard cableShard = new CharacterShard(cable);

            Character yondu = new Character("Yondu");
            CharacterShard yonduShard = new CharacterShard(yondu);

            Character danvers = new Character("Captain Marvel");
            CharacterShard danversShard = new CharacterShard(danvers);

            List<Opportunity> opportunities = new();
            opportunities.Add(new Opportunity()
            {
                Resource = cableShard,
                ResourceLocation = mystic1n9
            });
            opportunities.Add(new Opportunity()
            {
                Resource = yonduShard,
                ResourceLocation = heroes2n6
            });
            opportunities.Add(new Opportunity()
            {
                Resource = danversShard,
                ResourceLocation = heroes6n9
            });





            CharacterPriorityList foo = new();
            foo.Characters.Add(10, cable);
            foo.Characters.Add(5, yondu);

            List<Opportunity> shoppingList = foo.ShoppingList(opportunities);

            string bar = "";
            foreach (Opportunity o in shoppingList)
            {
                bar += o.ToString() + "\r\n";
            }
            return bar;
        }

    }
}
