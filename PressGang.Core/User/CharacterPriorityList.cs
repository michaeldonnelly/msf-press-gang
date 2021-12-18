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
            Dictionary<int, Opportunity> shoppingList = new();
            foreach (Opportunity opportunity in opportunities)
            {
                if (opportunity.ResourceLocation.GetType() == locationType)
                {
                    Resource resource = opportunity.Resource;
                    if (resource.GetType() == typeof(CharacterShard))
                    {
                        Character character = ((CharacterShard)resource).Character;
                        try
                        {
                            int priority = Characters[character];
                            shoppingList.Add(priority, opportunity);
                        }
                        catch
                        {
                            // Don't care - if it isn't there, don't add it to the list
                        }
                    }
                }
            }

            List<Opportunity> result = new();
            foreach (KeyValuePair<int, Opportunity> kvp in shoppingList.OrderBy(kvp => kvp.Key))
            {
                result.Add(kvp.Value);
            }
            return result;
        }
    }
}
