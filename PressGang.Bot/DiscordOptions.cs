using System;
namespace PressGang.Bot
{
    public class DiscordOptions
    {
        public const string Discord = nameof(Discord);

        public string TokenFilePath { get; set; }

        /// <summary>
        /// The Discord User ID of the person who owns the bot.  This determines who gets error messages.
        /// </summary>
        public ulong OwnerUserId { get; set; } 
    }
}
