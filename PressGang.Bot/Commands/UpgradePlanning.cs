using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using PressGang.Core;
using PressGang.Core.Data;
using PressGang.Core.StaticModels;

namespace PressGang.Bot.Commands
{
    public class UpgradePlanning : BaseCommandModule 
    {
        public PressGangContext _pressGangContext { private get; set; }

        [Command("ping")]
        public async Task PingCommand(CommandContext ctx)
        {
            await ctx.RespondAsync("ack");
        }

        [Command("hello")]
        public async Task GreetCommand(CommandContext ctx)
        {
            DiscordMember discordMember = ctx.Member;

            await ctx.RespondAsync("Greetings " + discordMember.Username);
        }

        [Command("campaign")]
        public async Task ListCommand(CommandContext ctx)
        {
            DiscordMember discordUser = ctx.Member;

            var foo = _pressGangContext.ContextId;
            
            //ShoppingList shoppingList = new(_context, discordUser.Id, discordUser.Username);
            //Character cap = _context.Characters.First(c => c.Name == "Captain America");
            //shoppingList.AddCharacter(cap, 10);
            //string response = shoppingList.DisplayOpportunities(LocationType.CampaignNode);
            //await ctx.RespondAsync(response);

            await ctx.RespondAsync("Greetings " + discordUser.Username);
        }

    }

}
