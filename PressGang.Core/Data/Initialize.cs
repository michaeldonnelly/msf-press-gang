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
            Store blitzStore = new Store("Blitz");
            new Store("Arena");
            new Store("War");

            Campaign heroes = new Campaign("Heros Assemble", 7);
            new Campaign("Villains United", 7);
            new Campaign("Nexus", 8);
            Campaign mystic = new Campaign("Mystic Forces Rising", 3);

            List<CampaignNode> lcn = mystic.Nodes();

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
            CampaignNode heroes3n3 = new CampaignNode("heroes3n3")
            {
                Campaign = heroes,
                Level = 3,
                Node = 3
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

            Character ultimateSpidey = new Character("Spider-Man (Miles)");
            CharacterShard ultimateSpideyShard = new CharacterShard(ultimateSpidey);

            List<Opportunity> opportunities = new();
            opportunities.Add(new Opportunity()
            {
                Resource = cableShard,
                ResourceLocation = mystic1n9
            });
            opportunities.Add(new Opportunity()
            {
                Resource = ultimateSpideyShard,
                ResourceLocation = blitzStore
            });
            opportunities.Add(new Opportunity()
            {
                Resource = ultimateSpideyShard,
                ResourceLocation = heroes3n3
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
            foo.Characters.Add(cable, 10);
            foo.Characters.Add(yondu, 10);
            foo.Characters.Add(ultimateSpidey, 99);
            //foo.Characters.Add(30, danvers);

            List<Opportunity> shoppingList = foo.ShoppingList(opportunities);

            string bar = "";
            int lineNumber = 0;
            foreach (Opportunity o in shoppingList)
            {
                lineNumber++;
                bar += String.Format("{0}. {1}\r\n", lineNumber.ToString(), o.ToString());
            }
            return bar;
        }

    }
}
