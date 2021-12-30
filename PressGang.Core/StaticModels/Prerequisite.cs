using System;
namespace PressGang.Core.StaticModels
{
    public class Prerequisite
    {
        public Prerequisite()
        {
        }

        public Prerequisite(Character character, Character dependsOn, int yellowStars, bool required = false)
        {
            Character = character;
            DependsOn = dependsOn;
            YellowStars = yellowStars;
            Required = required;
            Name = dependsOn.Name + " -> " + character.Name;
           
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CharacterId { get; set; }

        public virtual Character Character { get; set; }

        public int DependsOnId { get; set; }

        public virtual Character DependsOn { get; set; }

        public bool Required { get; set; }

        public int YellowStars { get; set; }

        public int? CharacterLevel { get; set; }

        public int? GearTier { get; set; }

        public int? Iso8ClassLevel { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
