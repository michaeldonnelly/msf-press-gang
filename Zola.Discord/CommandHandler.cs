using System;
using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using Zola.Database;
using Zola.Database.Models;
using Zola.Database.Reports;

namespace Zola.Discord
{
	public class CommandHandler
	{
        private DiscordSocketClient _discordClient;
        private MsfDbContext _dbContext;
        private GameReports _gameReports;


        public CommandHandler(MsfDbContext dbContext, DiscordSocketClient discordClient)
		{
            _dbContext = dbContext;
            _discordClient = discordClient;
            _gameReports = new(_dbContext);
        }

        public async Task SlashCommandHandler(SocketSlashCommand command)
        {
            
            Console.WriteLine(command.CommandName);

            switch (command.CommandName)
            {
                case "zola":
                    await Zola(command);
                    break;
                case "status-effect-search":
                    await StatusEffectSearch(command);
                    break;
                case "link":
                    await Link(command);
                    break;
                default:
                    await command.RespondAsync($"Unknown command: {command.CommandName}");
                    break;
            }            
        }

        private async Task Zola(SocketSlashCommand command)
        {
            await command.RespondAsync("I am alive.");
        }

        private async Task StatusEffectSearch(SocketSlashCommand command)
        {
            string response;
            SocketSlashCommandDataOption? effectOption = command.Data.Options.Where(o => o.Name == "effect").FirstOrDefault();
            if (effectOption is null)
            {
                response = "effect is required";
            }
            else
            {
                string effectName = (string)effectOption.Value;
                Effect? effect = _dbContext.Effects.Where(e => e.Name.ToLower() == effectName.ToLower()).FirstOrDefault();
                if (effect is null)
                {
                    response = "Allowed status effects are:";
                    foreach (Effect allowedEffect in _dbContext.Effects.ToList())
                    {
                        response += $"\r\n\t{allowedEffect.Name}";
                    }
                }
                else
                {
                    List<string> charactersWithEffect = _gameReports.CharactersWithEffect(effect.Id);
                    charactersWithEffect.Sort();
                    //var result = String.Join(", ", names.ToArray());
                    response = $"**{effect.Name}**: ";
                    response += String.Join(", ", charactersWithEffect.ToArray());
                    //response = _gameReports.CharactersWithEffect(effect.Id, false, true);
                }
            }

            
            await command.RespondAsync(response);
        }

        private async Task Link(SocketSlashCommand command)
        {
            Console.WriteLine("Link");
            string response = "";


            response += $"Number of users: {_dbContext.Users.Count()}";

            response += $"\r\nDiscord ID: {command.User.Id.ToString()}";


            ulong discordId = command.User.Id;

            User? user = _dbContext.Users.Where(u => u.DiscordId == discordId).FirstOrDefault();

            if (user is null)
            {
                user = new User()
                {
                    DiscordId = discordId
                };
                _dbContext.Add(user);
                _dbContext.SaveChanges();
                response += "\r\nCreated user";


            }
            else
            {
                response += "\r\nUser exists";
            }


            response += $"\r\nUser ID: {user.Id}";

            await command.RespondAsync(response);
        }
    }
}

