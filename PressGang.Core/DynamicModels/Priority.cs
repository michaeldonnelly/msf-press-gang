using System;
using PressGang.Core.StaticModels;

namespace PressGang.Core.DynamicModels
{
    public class Priority
    {
        public Priority()
        {
        }

        public Priority(User user, Resource resource, int priorityLevel)
        {
            User = user;
            Resource = resource;
            PriorityLevel = priorityLevel;
        }

        public int Id { get; set; }

        public User User { get; set; }

        public Resource Resource { get; set; }

        public int PriorityLevel { get; set; }
    }
}
