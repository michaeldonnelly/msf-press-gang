using System;
using System.Collections.Generic;

namespace PressGang.Core.System.Location
{
    public class FlashEvent : ResourceLocation
    {
        public FlashEvent(string name) : base(name)
        {
        }

        public List<Character> RequiredCharacters { get; set; }
    }
}
