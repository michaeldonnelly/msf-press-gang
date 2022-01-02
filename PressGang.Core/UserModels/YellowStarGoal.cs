using System;
using PressGang.Core.StaticModels;

namespace PressGang.Core.UserModels
{
    public class YellowStarGoal : CharacterGoal
    {
        public YellowStarGoal() : base()
        {
        }

        public YellowStarGoal(User user, Character character, int? rank) : base()
        {
            User = user;
            Character = character;
            Rank = rank;

            string name = character.Name;
            if (Rank != null)
            {
                name += $" at {Rank} YS";
            }
            name += $" for {User.UserName}";
            Name = name;
        }

        public int? Rank { get; set; }

    }
}
