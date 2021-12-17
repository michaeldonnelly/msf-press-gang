using System;
namespace PressGang.Core.System.Mode
{
    public partial class GameMode
    {
        public GameMode(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
