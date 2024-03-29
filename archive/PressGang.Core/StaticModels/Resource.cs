﻿using System;
using System.Collections.Generic;

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

        public virtual List<Opportunity> Opportunities { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public enum ResourceType
    {
        CharacterShard
    }
}
