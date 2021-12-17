using System;
using PressGang.Core.System;
using PressGang.Core.System.GameMode;


namespace PressGang.Core.Data
{
    public static class Initialize
    {
        public static void System()
        {
            new Store("Main");
            new Store("Raid");
            new Store("Blitz");
            new Store("Arena");
            new Store("War");

            new Campaign("Heros Assemble");
            new Campaign("Villains United");
            new Campaign("Nexus");
            new Campaign("Mystic Forces Rising");


        }

    }
}
