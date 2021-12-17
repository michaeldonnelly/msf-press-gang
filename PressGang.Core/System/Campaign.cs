using System;
namespace PressGang.Core.System
{
    public class Campaign
    {
        public Campaign(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

    }
}
