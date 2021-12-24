using System;
using System.Collections.Generic;

namespace PressGang.Core.UserModels
{
    public class User
    {
        public User()
        {
        }

        public User(ulong discordId, string userName)
        {
            DiscordId = discordId;
            UserName = userName;
        }

        public int Id { get; set; }

        public ulong DiscordId { get; set; }

        public string UserName { get; set; }

        public virtual List<Goal> Goals { get; set; } = new();

        public override string ToString()
        {
            return String.Format("{0} [{1}, {2}]", UserName, DiscordId.ToString(), Id.ToString());
        }
    }
}
