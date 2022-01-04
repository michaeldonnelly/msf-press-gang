using System;
using PressGang.Core.StaticModels;

namespace PressGang.Core.UserModels
{
    public partial class Goal : IGoal
    {
        public Goal()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int Priority { get; set; }

        public override string ToString()
        {
            return $"{Name} for {User}";
        }
    }
}
