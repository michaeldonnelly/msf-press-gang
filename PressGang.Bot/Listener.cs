using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using PressGang.Core;
using PressGang.Core.DatabaseContext;
using PressGang.Core.StaticModels;
using PressGang.Bot.Commands;

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
            RegisterCommandListeners(discordOptions, discordClient, serviceProvider);            
            return discordClient;
        }

        private static string DiscordToken(DiscordOptions discordOptions)
        {
            string tokenFile = discordOptions.TokenFilePath;
            string token = File.ReadAllText(tokenFile);
            return token;
        }

        private static void RegisterCommandListeners(DiscordOptions discordOptions, DiscordClient discordClient, IServiceProvider serviceProvider)
        {
            CommandsNextConfiguration commandsNextConfiguration = new()
            {
                StringPrefixes = new[] { discordOptions.CommandPrefix },
                Services = serviceProvider
            };

            CommandsNextExtension commands = discordClient.UseCommandsNext(commandsNextConfiguration);
            commands.RegisterCommands<AdminHandlers>();
            commands.RegisterCommands<HelpHandlers>();
            commands.RegisterCommands<AllianceHandlers>();
            commands.RegisterCommands<StaticGameHandlers>();
            if (discordOptions.EnablePressGang)
            {
                commands.RegisterCommands<PressGangHandlers>();
            }
        }

        //private static void RegisterErrorHandler(DiscordClient discordClient, DiscordOptions discordOptions)
        //{
        //    discordClient.ClientErrored += ClientErrorHandler;
        //}

        //private static async Task ClientErrorHandler(DiscordClient discordClient, ClientErrorEventArgs clientErrorEventArgs)
        //{
        //}

        public static async Task Connect(DiscordOptions discordOptions, DiscordClient discordClient)
        {
            string status = "you! '" + discordOptions.CommandPrefix + "help' shows what I can do!";
            DiscordActivity discordActivity = new(status, ActivityType.ListeningTo);
            await discordClient.ConnectAsync(discordActivity);
            await Task.Delay(-1);
        }

       
    }
}
