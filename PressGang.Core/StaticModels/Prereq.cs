using System;
namespace PressGang.Core.StaticModels
{
    public class Prereq
    {
        public Prereq()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CharacterId { get; set; }

        public virtual Character Character { get; set; }

        public int DependsOnId { get; set; }

        public virtual Character DependsOn { get; set; }
    }
}
