using System;
using System.Collections.Generic;
using System.Linq;
using PressGang.Core.System;

namespace PressGang.Core.User
{
    public class CharacterPriorityList
    {
        public CharacterPriorityList()
        {
            Characters = new();
        }

        public Dictionary<int, Character> Characters { get; set; }

        public List<Character> PriorityForMode(Type gameMode, List<Opportunity> opportunities)
        {
            Dictionary<int, Character> shoppingList = new();
            foreach (Opportunity opportunity in opportunities)
            {
                if (opportunity.ResourceLocation.GetType() == gameMode)
                {
                    var resource = opportunity.Resource;
                    if (resource.GetType() == typeof(CharacterShard))
                    {
                        Character character = ((CharacterShard)resource).Character;
                        int? priority = Characters.FirstOrDefault(kvp => kvp.Value == character).Key;
                        if (priority != null)
                        {
                            shoppingList.Add((int)priority, character);
                        }
                    }
                }
            }

            List<Character> result = new();
            foreach (KeyValuePair<int, Character> kvp in shoppingList.OrderBy(kvp => kvp.Key))
            {
                result.Add(kvp.Value);
            }
            return result;
        }
    }
}
