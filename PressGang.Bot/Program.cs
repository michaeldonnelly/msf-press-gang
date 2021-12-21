using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;
using Microsoft.Extensions.Configuration;
using PressGang.Core;

namespace PressGang.Bot
{
    class Program
    {
        private static AppSettings _appSettings = new AppSettings();


        static void Main(string[] args)
        {
            AppConfig.LoadAppSettings(_appSettings);

            Debug.WriteLine(AppConfig.DiscordToken(_appSettings));
            System.Console.WriteLine("Hello World!");
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = AppConfig.DiscordToken(_appSettings),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            }) ;

            discord.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.ToLower().StartsWith("ping"))
                    await e.Message.RespondAsync("ack");
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);

        }
    }
}
