using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PressGang.Core;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DatabaseOperations;
using PressGang.Core.StaticModels;


// 559173272306974740
namespace PressGang.Bot
{
    public class CommandHandlers : BaseCommandModule 
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

        [Command("wait")]
        public async Task WaitCommand(CommandContext ctx, int milliseconds)
        {
            Thread.Sleep(milliseconds);
            string response = String.Format("Waited for {0} seconds", (milliseconds / 1000).ToString());
            await ctx.RespondAsync(response);
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


        [Command("add")]
        public async Task AddCommand(CommandContext ctx, string characterName, int priorityLevel)
        {
            Character character = LookUp.Character(PressGangContext, characterName);
            string response;
            if (character == null)
            {
                response = "Not found: " + characterName;
            }
            else
            {
                DiscordMember discordUser = ctx.Member;
                ShoppingList shoppingList = new(PressGangContext, discordUser.Id, discordUser.Username);
                shoppingList.AddCharacter(character, priorityLevel);
                response = "Added " + character.Name;
            }

            await ctx.RespondAsync(response);
        }
      
        [Command("list")]
        public async Task ListCommand(CommandContext ctx, string subject = null)
        {
            try
            {
                string tableName = LookUp.FindTableByName(PressGangContext, subject);
                if (tableName == null)
                {
                    string error = "Sorry, I can't find a table named '" + subject + "'\r\n";
                    await ctx.RespondAsync(error);
                    return;
                }

                IEnumerable set = (IEnumerable)PressGangContext.GetType().GetProperty(tableName).GetValue(PressGangContext, null);

                Queue<string> response = new();
                response.Enqueue(tableName);
                response.Enqueue(DiscordUtils.MonospaceUnderline(tableName.Length));
                foreach(var entry in set)
                {
                    response.Enqueue(entry.ToString());
                }

                DiscordUtils.Respond(ctx, response);
            }
            catch (Exception ex)
            {
                DiscordUtils.HandleError(ctx, ex);
            }
        }

        [Command("db")]
        public async Task DbCommand(CommandContext ctx)
        {
            // TODO: restrict to owner
            Queue<string> response = new();
            response.Enqueue("PressGang Database Status");
            response.Enqueue(DiscordUtils.MonospaceUnderline(25));
            try
            {
                response.Enqueue("CanConnect: " + PressGangContext.Database.CanConnect().ToString());
                response.Enqueue("ProviderName: " + PressGangContext.Database.ProviderName.ToString());
                response.Enqueue("Record counts");
                IRelationalModel relationalModel = PressGangContext.Model.GetRelationalModel();
                foreach (ITable table in relationalModel.Tables)
                {
                    string tableName = table.Name;
                    IEnumerable<object> set = (IEnumerable<object>)PressGangContext.GetType().GetProperty(tableName).GetValue(PressGangContext, null);
                    int recordCount = set.Count();
                    response.Enqueue(String.Format("\t{0}: {1}", tableName, recordCount.ToString()));
                }

                DiscordUtils.Respond(ctx, response);
            }
            catch (Exception ex)
            {
                DiscordUtils.HandleError(ctx, ex);
            }
        }

        [Command("my")]
        public async Task MyCommand(CommandContext ctx)
        {
            DiscordMember discordUser = ctx.Member;
            ShoppingList shoppingList = new(PressGangContext, discordUser.Id, discordUser.Username);
            string response = shoppingList.DisplayPriorities();
            await ctx.RespondAsync(response);
        }

        [Command("campaign")]
        public async Task CampaignCommand(CommandContext ctx)
        {
            DiscordMember discordUser = ctx.Member;
            ShoppingList shoppingList = new(PressGangContext, discordUser.Id, discordUser.Username);
            try
            {
                string response = shoppingList.DisplayOpportunities(LocationType.CampaignNode);
                await ctx.RespondAsync(response);
            }
            catch (Exception ex)
            {
                DiscordUtils.HandleError(ctx, ex);
            }
        }
    }
}
