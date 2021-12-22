using System;
using System.Linq;
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
        public PressGangContext PressGangContext { private get; set; }

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

        [Command("char")]
        public async Task CharCommand(CommandContext ctx)
        {
            string response = "";
            foreach (Character character in PressGangContext.Characters)
            {
                response += character.Name + "\r\n";
            }
            await ctx.RespondAsync(response);
        }





        [Command("campaign")]
        public async Task CampaignCommand(CommandContext ctx)
        {
            DiscordMember discordUser = ctx.Member;
            ShoppingList shoppingList = new(PressGangContext, discordUser.Id, discordUser.Username);
            Character cap = PressGangContext.Characters.First(c => c.Name == "Captain America");
            shoppingList.AddCharacter(cap, 10);
            string response = shoppingList.DisplayOpportunities(LocationType.CampaignNode);
            await ctx.RespondAsync(response);            
        }

    }

}
