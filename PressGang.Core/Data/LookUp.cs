using System;
using System.Collections.Generic;
using System.Linq;
using PressGang.Core.StaticModels;

namespace PressGang.Core.Data
{
    public static class LookUp
    {
        public static Resource Shard(PressGangContext context, Character character)
        {
            try
            {
                Resource shard = context.Resources.First(r =>
                        (r.ResourceType == ResourceType.CharacterShard)
                        && (r.Character == character)
                    );
                return shard;
            }
            catch(InvalidOperationException)
            {
                return null;
            }
        }

        public static Character Character(PressGangContext context, string name)
        {
            List<Character> results = context.Characters.Where(c => c.Name.ToLower().StartsWith(name)).ToList();
            if (results.Count == 1)
            {
                return results[0];
            }

            return null;
        }
    }
}
