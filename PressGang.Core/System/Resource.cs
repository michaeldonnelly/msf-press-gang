using System;

namespace PressGang.Core.System
{
    public partial class Resource
    {
        public Resource()
        {
        }

        public Resource(Character character) 
        {
            this.Name = character.Name + " Shard";
            Character = character;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Location ResourceLocation { get; set; }

        public Character Character { get; set; }

    }
}
