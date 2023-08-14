using System;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DatabaseOperations;
using PressGang.Core.StaticModels;

namespace PressGang.Core.UserModels
{
    public partial class CharacterGoal : Goal
    {
        public CharacterGoal() : base()
        {
        }

        public int CharacterId { get; set; }

        public virtual Character Character { get; set; }

        public override Resource Resource(PressGangContext context)
        {
            context.Entry(this).Reference(g => g.Character).Load();
            return LookUp.Shard(context, Character);
        }

    }
}
