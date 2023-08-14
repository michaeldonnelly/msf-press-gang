using System;
namespace PressGang.Core.StaticModels
{
    public class PrerequisiteCharacter
    {
        public PrerequisiteCharacter()
        {
        }

        public PrerequisiteCharacter(Character character, Character dependsOn, bool required = false)
        {
            Character = character;
            DependsOn = dependsOn;
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

        public override string ToString()
        {
            return Name;
        }
    }
}
