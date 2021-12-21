using System;
using PressGang.Core.StaticModels;

namespace PressGang.Core.DynamicModels
{
    public class Priority
    {
        public Priority()
        {
        }

        public int Id { get; set; }

        public User User { get; set; }

        public Resource Resource { get; set; }

        public int PriorityLevel { get; set; }
    }
}
