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
    public class Listener
    {
        private readonly DiscordClient _discord;
        public Listener(DiscordOptions discordOptions)
        {
            
            DiscordConfiguration discordConfiguration = new()
            {
                Token = DiscordToken(discordOptions),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            };
            DiscordClient discordClient = new(discordConfiguration);
            RegisterCommandListeners(discordClient);
            _discord = discordClient;
        }

        private string DiscordToken(DiscordOptions discordOptions)
        {
            string tokenFile = discordOptions.TokenFilePath;
            string token = File.ReadAllText(tokenFile);
            return token;
        }

        private void RegisterCommandListeners(DiscordClient discordClient)
        {
            CommandsNextConfiguration commandsNextConfiguration = new()
            {
                StringPrefixes = new[] { "!" }
            };

            CommandsNextExtension commands = discordClient.UseCommandsNext(commandsNextConfiguration);
            commands.RegisterCommands<UpgradePlanning>();
        }

        public async Task Connect()
        {
            await _discord.ConnectAsync();
            await Task.Delay(-1);
        }

       
    }
}
