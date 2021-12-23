using System;

namespace PressGang.Core.StaticModels
{
    public partial class Resource
    {
        public Resource()
        {
        }

        public Resource(Character character) 
        {
            this.Name = character.Name + " shard";
            Character = character;
            ResourceType = ResourceType.CharacterShard;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }

        public int? CharacterId { get; set; }

        public virtual Character Character { get; set; }

    }

    public enum ResourceType
    {
        CharacterShard
    }
}
