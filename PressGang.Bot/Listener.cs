using System;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace PressGang.Bot
{
    public static class Listener
    {

        public static async Task MessageCreatedHandler(MessageCreateEventArgs e)
        {
            DiscordUser discordUser = e.Author;
            string message = e.Message.Content.ToLower();

            if (message.StartsWith("ping"))
            {
                await e.Message.RespondAsync("ack");
            }
            await Task.Delay(-1);
        }
    }
}
