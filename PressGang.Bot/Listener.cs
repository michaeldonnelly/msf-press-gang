using System;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using PressGang.Core;
using PressGang.Core.Data;
using PressGang.Core.StaticModels;

namespace PressGang.Bot
{
    public class Listener
    {
        private readonly AppSettings _appSettings;
        private readonly PressGangContext _context;
        private readonly DiscordClient _discord;

        public Listener(AppSettings appSettings, PressGangContext context)
        {
            _appSettings = appSettings;
            _context = context;
            DiscordConfiguration discordConfiguration = new()
            {
                Token = AppConfig.DiscordToken(_appSettings),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            };
            _discord = new(discordConfiguration);
            _discord.MessageCreated += (s, e) => MessageCreatedHandler(s, e);
        }

        public async Task Connect()
        {
            await _discord.ConnectAsync();
            await Task.Delay(-1);
        }

        public Task MessageCreatedHandler(DiscordClient s, MessageCreateEventArgs e)
        {
            _ = Task.Run(async () =>
            {
                string message = e.Message.Content.ToLower();
                //Console.WriteLine(e.Author.Username + ": " + message);

                if (message.StartsWith("ping"))
                {
                    await e.Message.RespondAsync("ack");
                }
                //else if (message.StartsWith("list"))
                //{
                //    DiscordUser discordUser = e.Author;
                //    ShoppingList shoppingList = new(context, discordUser.Id, discordUser.Username);
                //    Character cap = context.Characters.First(c => c.Name == "Captain America");
                //    shoppingList.AddCharacter(cap, 10);
                //    string response = shoppingList.DisplayOpportunities(LocationType.CampaignNode);
                //    await e.Message.RespondAsync(response);
                //}
                await Task.Delay(-1);
            });
            return Task.CompletedTask;
        }        
    }
}
