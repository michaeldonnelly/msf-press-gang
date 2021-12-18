using System;
using System.Collections.Generic;
using PressGang.Core.System;

namespace PressGang.Core.User
{
    public class CharacterPriorityList
    {
        public CharacterPriorityList()
        {
        }

        public Dictionary<int, Character> Characters { get; set; }

        public Character[] PriorityForMode(Type gameMode)
        {
            return null;
        }
    }
}
