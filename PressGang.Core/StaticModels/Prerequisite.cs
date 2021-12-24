using System;
namespace PressGang.Core.StaticModels
{
    public class Prerequisite
    {
        public Prerequisite()
        {
        }

        public Prerequisite(Character character, Character dependsOn)
        {
            Character = character;
            DependsOn = dependsOn;
            Name = dependsOn.Name + " -> " + character.Name;
           
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CharacterId { get; set; }

        public virtual Character Character { get; set; }

        public int DependsOnId { get; set; }

        public virtual Character DependsOn { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
