using System;
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

    }
}
