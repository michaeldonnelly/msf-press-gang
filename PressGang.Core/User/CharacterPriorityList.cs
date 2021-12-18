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

        public Dictionary<int, Character> Characters { get; set; }

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
                        int? priority = Characters.FirstOrDefault(kvp => kvp.Value == character).Key;
                        if (priority != null)
                        {
                            shoppingList.Add((int)priority, opportunity);
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
