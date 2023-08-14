using System;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

namespace PressGang.Test
{
    public static class Constants
    {
        public static User Hawkshaw { get
            {
                return new User(12345, "Hawkshaw");
            }
        }

        public static Character Peter { get
            {
                return new Character("Spider-Man");
            }
        }

        public static Character Logan { get
            {
                return new Character("Wolverine");
            }
        }

        public static Character Carol {  get
            {
                return new Character("Captain Marvel");
            }
        }
    }
}
