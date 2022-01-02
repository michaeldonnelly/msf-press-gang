using System;
using System.Collections.Generic;

namespace PressGang.Core.StaticModels
{
    public class Character
    {
        public Character(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// The character key from msf.gg's alias file
        /// </summary>
        public string CharacterKey { get; set; }

        public virtual List<CharacterAlias> CharacterAliases { get; set; }

        public List<string> Aliases()
        {
            List<string> aliases = new();
            foreach (CharacterAlias ca in CharacterAliases)
            {
                aliases.Add(ca.Alias);
            }
            return aliases;
        }

        public int? MinimumUnlockStars { get; set; }

        public virtual List<PrerequisiteCharacter> PrerequisiteCharacters { get; set; } = new();

        public virtual List<PrerequisiteStats> PrerequisiteStats { get; set; } = new();

        public virtual Resource Shard { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
