using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using PressGang.Core;

namespace PressGang.Bot
{
    public static class Listener
    {

        public static async Task Initialize(AppSettings appSettings)
        {
            DiscordClient discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = AppConfig.DiscordToken(appSettings),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });
            discord.MessageCreated += (s, e) => Listener.MessageCreatedHandler(e);
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }

        private static DiscordClient EstablishClient(AppSettings appSettings)
        {
            DiscordClient discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = AppConfig.DiscordToken(appSettings),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });
            return discord;
        }


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
