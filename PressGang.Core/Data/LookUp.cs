using System;
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
    }
}
