﻿using System;
namespace PressGang.Core.System
{
    public class ResourceLocation
    {
        public ResourceLocation(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
