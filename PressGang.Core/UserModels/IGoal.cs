using System;
namespace PressGang.Core.UserModels
{
    public interface IGoal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int Priority { get; set; }
    }
}
