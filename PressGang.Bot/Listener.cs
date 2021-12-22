using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using PressGang.Bot.Commands;
using PressGang.Core;
using PressGang.Core.Data;
using PressGang.Core.StaticModels;

namespace PressGang.Bot
{
    public static class Listener
    {
        public static DiscordClient Initialize(DiscordOptions discordOptions, IServiceProvider serviceProvider)
        {
            
            DiscordConfiguration discordConfiguration = new()
            {
                Token = DiscordToken(discordOptions),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            };
            DiscordClient discordClient = new(discordConfiguration);
            RegisterCommandListeners(discordClient, serviceProvider);
            return discordClient;
        }

        private static string DiscordToken(DiscordOptions discordOptions)
        {
            string tokenFile = discordOptions.TokenFilePath;
            string token = File.ReadAllText(tokenFile);
            return token;
        }

        private static void RegisterCommandListeners(DiscordClient discordClient, IServiceProvider serviceProvider)
        {
            CommandsNextConfiguration commandsNextConfiguration = new()
            {
                StringPrefixes = new[] { "!" },
                Services = serviceProvider
            };

            CommandsNextExtension commands = discordClient.UseCommandsNext(commandsNextConfiguration);
            commands.RegisterCommands<UpgradePlanning>();
        }

        public static async Task Connect(DiscordClient discordClient)
        {
            await discordClient.ConnectAsync();
            await Task.Delay(-1);
        }

       
    }
}
