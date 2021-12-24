using System;
using PressGang.Core.StaticModels;

namespace PressGang.Core.UserModels
{
    public class Goal
    {
        public Goal()
        {
        }

        public Goal(User user, Character character, int priority, int? yellowStarRank = null)
        {
            GoalType = GoalType.YellowStarRank;
            User = user;
            Character = character;
            YellowStarRank = yellowStarRank;
            Name = character.Name + " for " + user.UserName;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public GoalType GoalType { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int Priority { get; set; }

        public int CharacterId { get; set; }

        public virtual Character Character { get; set; }

        public int? YellowStarRank { get; set; }
    }

    public enum GoalType
    {
        YellowStarRank
    }
}
