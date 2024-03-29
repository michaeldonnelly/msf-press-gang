﻿using System;
namespace PressGang.Core.StaticModels
{
    public class CharacterAlias
    {
        public CharacterAlias()
        { }

        public CharacterAlias(Character character, string alias)
        {
            Character = character;
            Alias = alias.Trim();
            Name = $"{Alias} -> {Character.Name}";
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CharacterId { get; set; }

        public virtual Character Character { get; set; }

        public string Alias { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
