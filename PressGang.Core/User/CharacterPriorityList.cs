using System;
using System.Collections.Generic;
using System.Linq;
using PressGang.Core.System;
using PressGang.Core.System.Location;
using PressGang.Core.System.Mode;

namespace PressGang.Core.User
{
    public class CharacterPriorityList
    {
        public CharacterPriorityList()
        {
            Characters = new();
        }

        public Dictionary<Character, int> Characters { get; set; }

        public List<Opportunity> ShoppingList(List<Opportunity> opportunities)
        {
            Type locationType = typeof(CampaignNode);
            Dictionary<int, List<Opportunity>> shoppingList = new();
//            Dictionary<int, Opportunity> shoppingList = new();
            foreach (Opportunity opportunity in opportunities)
            {
                if (opportunity.ResourceLocation.GetType() == locationType)
                {
                    Resource resource = opportunity.Resource;
                    if (resource.GetType() == typeof(CharacterShard))
                    {
                        Character character = ((CharacterShard)resource).Character;

                        if (Characters.ContainsKey(character))
                        {
                            int priority = Characters[character];
                            if (shoppingList.ContainsKey(priority))
                            {
                                shoppingList[priority].Add(opportunity);
                            }
                            else
                            {
                                List<Opportunity> lo = new() { opportunity };
                                shoppingList.Add(priority, lo);
                            }
                        }

                    }
                }
            }

            List<Opportunity> result = new();
            foreach (KeyValuePair<int, List<Opportunity>> kvp in shoppingList.OrderBy(kvp => kvp.Key))
            {
                foreach (Opportunity opportunity in kvp.Value)
                {
                    result.Add(opportunity);
                }                
            }
            return result;
        }
    }
}
