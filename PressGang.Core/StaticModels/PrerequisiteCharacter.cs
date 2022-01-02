﻿using System;
namespace PressGang.Core.StaticModels
{
    public class PrerequisiteCharacter
    {
        public PrerequisiteCharacter()
        {
        }

        public PrerequisiteCharacter(Character character, Character dependsOn, int yellowStars, bool required = false)
        {
            Character = character;
            DependsOn = dependsOn;
            RequiredYellowStars = yellowStars;
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

        public int UnlockAtStars { get; set; }

        public int RequiredYellowStars { get; set; }

        public int? RequiredCharacterLevel { get; set; }

        public int? RequiredGearTier { get; set; }

        public int? RequiredIso8ClassLevel { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}