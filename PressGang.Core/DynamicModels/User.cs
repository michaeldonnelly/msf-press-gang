using System;
namespace PressGang.Core.DynamicModels
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
    }
}
