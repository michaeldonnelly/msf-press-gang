using System;
using PressGang.Core.DatabaseContext;
using PressGang.Core.StaticModels;

namespace PressGang.Core.UserModels
{
    public interface IGoal : IPressGangRecord
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int Priority { get; set; }

        public Resource Resource(PressGangContext context);
    }
}
