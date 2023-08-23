using System;
using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using Zola.Database;
using Zola.Database.Models;
using Zola.Database.Reports;
using Zola.MsfClient.Authentication;

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
                case "relink":
                    await Link(command, forceLink: true);
                    break;
                case "unlink":
                    await Unlink(command);
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

        private async Task Unlink(SocketSlashCommand command)
        {
            ulong discordId = command.User.Id;
            User? user = _dbContext.Users.Where(u => u.DiscordId == discordId).FirstOrDefault();
            string response;
            if (user is null)
            {
                response = "Your account is not linked.";
            }
            else
            {
                if (user.RefreshToken is null)
                {
                    response = "Your account is not linked.";
                }
                else
                {

                    user.AccessToken = null;
                    user.AccessTokenExpiration = null;
                    user.RefreshToken = null;
                    _ = _dbContext.SaveChangesAsync();  
                    response = "Your account has been unlinked.";
                }
            }
            await command.RespondAsync(response);
        }


        private async Task Link(SocketSlashCommand command, Boolean forceLink = false)
        {
            Console.WriteLine("Link");
            string response = "";


            response += $"Number of users: {_dbContext.Users.Count()}";

            response += $"\r\nDiscord ID: {command.User.Id.ToString()}";






            ulong discordId = command.User.Id;
            ZolaUserTokenStore userTokenStore = new(_dbContext, discordId);
            
            response += $"\r\nUser ID: {userTokenStore.UserId}";

            if ((userTokenStore.RefreshToken is null) || forceLink)
            {
                Ticket ticket = _dbContext.NewTicket(userTokenStore.User);
                string url = "http://localhost:8443/Home/Link?ticket=" + ticket.Id;
                response += $"\r\n{url}";
            }
            else
            {
                response += "\r\nAccount is linked to MSF.";
            }
            

            await command.RespondAsync(response);
        }
    }
}

