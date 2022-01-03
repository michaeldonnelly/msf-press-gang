using System;
using PressGang.Core.StaticModels;

namespace PressGang.Core.UserModels
{
    public class YellowStarGoal : CharacterGoal
    {
        public YellowStarGoal() : base()
        {
        }

        public YellowStarGoal(User user, Character character, int? rank = null, int? priority = null) : base()
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

            if (priority != null)
            {
                Priority = (int)priority;
            }
        }

        public int? Rank { get; set; }

    }
}
