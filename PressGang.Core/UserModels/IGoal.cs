using System;
namespace PressGang.Core.UserModels
{
    public interface IGoal : IPressGangRecord
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int Priority { get; set; }
    }
}
