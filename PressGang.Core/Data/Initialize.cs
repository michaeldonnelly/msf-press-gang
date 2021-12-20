using System;
using System.Collections.Generic;
using System.Diagnostics;
using PressGang.Core.System;
using PressGang.Core.User;

namespace PressGang.Core.Data
{
    public static class Initialize
    {
        public static string System(PressGangContext context)
        {
            foreach (Opportunity opportunity in context.Opportunties)
            {
                Debug.WriteLine(opportunity.ToString());
            }

            new Location("Main");
            new Location("Raid");
            Location blitzStore = new Location("Blitz");
            new Location("Arena");
            new Location("War");

            Campaign heroes = new Campaign("Heros Assemble", 7);
            new Campaign("Villains United", 7);
            new Campaign("Nexus", 8);
            Campaign mystic = new Campaign("Mystic Forces Rising", 3);

            List<Location> lcn = mystic.Nodes();

            Location mystic1n9 = new Location("mystic1n9")
            {
                Campaign = mystic,
                Level = 1,
                Node = 9
            };

            Location heroes2n6 = new Location("heroes2n6")
            {
                Campaign = heroes,
                Level = 2,
                Node = 6
            };
            Location heroes3n3 = new Location("heroes3n3")
            {
                Campaign = heroes,
                Level = 3,
                Node = 3
            };
            Location heroes6n9 = new Location("heroes6n9")
            {
                Campaign = heroes,
                Level = 6,
                Node = 9
            };


            Character cable = new Character("Cable");
            Resource cableShard = new Resource(cable);

            Character yondu = new Character("Yondu");
            Resource yonduShard = new Resource(yondu);

            Character danvers = new Character("Captain Marvel");
            Resource danversShard = new Resource(danvers);

            Character ultimateSpidey = new Character("Spider-Man (Miles)");
            Resource ultimateSpideyShard = new Resource(ultimateSpidey);

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
