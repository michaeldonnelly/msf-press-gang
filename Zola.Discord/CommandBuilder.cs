using System;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;
using Zola.Database;
using Zola.Database.Models;

namespace Zola.Discord
{
	public class CommandBuilder
	{
        private DiscordSocketClient _discordClient;
        private SocketGuild _guild;
        private MsfDbContext _dbContext;
        private bool _globalCommands = false;

        public CommandBuilder(MsfDbContext dbContext, DiscordSocketClient discordClient, ulong guildId)
		{
            _dbContext = dbContext;
            _discordClient = discordClient;
            _guild = _discordClient.GetGuild(guildId);
        }

        public async void Deregister()
        {
            Console.WriteLine("Deregistering slash commands.");
            await _guild.DeleteApplicationCommandsAsync();
            List<ApplicationCommandProperties> applicationCommandProperties = new();  // null - just get rid of everything
            await _discordClient.BulkOverwriteGlobalApplicationCommandsAsync(applicationCommandProperties.ToArray());
        }


        public async void Register()
		{
            Console.WriteLine("Registering slash commands.");
            //var guildCommand = new SlashCommandBuilder();
            //guildCommand.WithName("first-command");
            //guildCommand.WithDescription("This is my first guild slash command!");

            //var globalCommand = new SlashCommandBuilder();
            //globalCommand.WithName("first-global-command");
            //globalCommand.WithDescription("This is my first global slash command");


            List<ApplicationCommandProperties> commands = new();

            SlashCommandBuilder zola = new();
            zola.WithName("zola");
            zola.WithDescription("Check the status of the zola bot.");


            SlashCommandOptionBuilder effectOptions = new SlashCommandOptionBuilder()
                .WithName("effect")
                .WithDescription("The status effect for which you want to search")
                .WithRequired(true);
            //foreach(Effect effect in _dbContext.Effects)
            //{
            //    effectOptions.AddChoice(effect.Name, effect.Name);
            //}
            effectOptions.WithType(ApplicationCommandOptionType.String);

            SlashCommandBuilder statusEffectSearch = new SlashCommandBuilder()
                .WithName("status-effect-search")
                .WithDescription("Find all characters whose abilities refers to a status effect")
                .AddOption(effectOptions);


            SlashCommandBuilder link = new SlashCommandBuilder()
                .WithName("link")
                .WithDescription("Connect Zola to your MSF account");
                

            //        .AddOption(new SlashCommandOptionBuilder()
            //            .WithName("effect")
            //            .WithDescription("The status effect for which you want to search")
            //            .WithRequired(true)
            //            .AddChoice("Terrible", 1)
            //            .AddChoice("Meh", 2)
            //            .AddChoice("Good", 3)
            //            .AddChoice("Lovely", 4)
            //            .AddChoice("Excellent!", 5)
            //            .WithType(ApplicationCommandOptionType.Integer)
            //);


            commands.Add(zola.Build());
            commands.Add(statusEffectSearch.Build());
            commands.Add(link.Build());
            


            try
            {
                if (_globalCommands)
                {
                    await _discordClient.BulkOverwriteGlobalApplicationCommandsAsync(commands.ToArray());
                }
                else
                {
                    await _guild.BulkOverwriteApplicationCommandAsync(commands.ToArray());
                }


                //await _guild.CreateApplicationCommandAsync(guildCommand.Build());
                //await _discordClient.CreateGlobalApplicationCommandAsync(globalCommand.Build());
            }
            catch (ApplicationCommandException exception)
            {
                // If our command was invalid, we should catch an ApplicationCommandException. This exception contains the path of the error as well as the error message. You can serialize the Error field in the exception to get a visual of where your error is.
                var json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);

                // You can send this error somewhere or just print it to the console, for this example we're just going to print it.
                Console.WriteLine(json);
            }
        }



	}
}

