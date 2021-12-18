using System;
namespace PressGang.Core.System
{
    public class CharacterShard : Resource
    {
        public CharacterShard(Character character)
        {
            this.Name = character.Name + " Shard";
            Character = character; 
        }

        public Character Character { get; set; }
    }
}
