﻿using System;
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

        public virtual List<Prerequisite> Prerequisites { get; set; } = new();

        public virtual Resource Shard { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
