using System;
namespace PressGang.Core.System
{
    public class Character
    {
        public Character(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
