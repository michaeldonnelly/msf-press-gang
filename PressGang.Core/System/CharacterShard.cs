using System;
namespace PressGang.Core.System
{
    public class CharacterShard : Resource
    {
        public CharacterShard() : base()
        {

        }

        public CharacterShard(Character character) : base()
        {
            this.Name = character.Name + " Shard";
            Character = character; 
        }

    }
}
