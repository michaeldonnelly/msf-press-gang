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
using PressGang.Core.Reports;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;


// 559173272306974740
namespace PressGang.Bot.Commands
{
    public class CommandHandlers : BaseCommandModule 
    {
        public PressGangContext PressGangContext { private get; set; }
        
        [Command("add")]
        public async Task AddCommand(CommandContext ctx, string characterName, int priorityLevel)
        {
            try
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
                    User user = LookUp.User(PressGangContext, discordUser.Id, discordUser.Username);
                    CharacterPriorities characterPriorities = new(PressGangContext, user);
                    Goal goal = characterPriorities.Add(character, priorityLevel);
                    response = "Added " + goal.Character.Name;
                }

                await DiscordUtils.Respond(ctx, response);
            }
            catch(Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
            }
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
                response.Enqueue("");  // TODO: figure out why tableName causing the first line to be ignored
                response.Enqueue(tableName);
                response.Enqueue(DiscordUtils.MonospaceUnderline(tableName.Length));
                foreach(var entry in set)
                {
                    response.Enqueue(entry.ToString());
                }

                await DiscordUtils.Respond(ctx, response);
            }
            catch (Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
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

                await DiscordUtils.Respond(ctx, response);
            }
            catch (Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
            }
        }

        [Command("my")]
        public async Task MyCommand(CommandContext ctx, string subject = "")
        {
            
            try
            {
                DiscordMember discordUser = ctx.Member;
                User user = LookUp.User(PressGangContext, discordUser.Id, discordUser.Username);
                CharacterPriorities characterPriorities = new(PressGangContext, user);
                //if (subject == null)
                //{
                //    subject = "derived";
                //}

                Queue<string> response = new();

                List<Character> cl;
                if (subject.ToLower() == "base")
                {
                    cl = characterPriorities.Characters();
                    response.Enqueue("Your prioritied characters");
                }
                else
                {
                    cl = characterPriorities.CharactersWithPrerequisites();
                    response.Enqueue("Your prioritied characters (with prerequisites)");
                }

                foreach (Character character in cl)
                {
                    response.Enqueue(character.ToString());
                }
                await DiscordUtils.Respond(ctx, response);
            }
            catch (Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
            }
        }

        [Command("farm")]
        public async Task FarmCommand(CommandContext ctx)
        {
            try
            {
                DiscordMember discordUser = ctx.Member;
                User user = LookUp.User(PressGangContext, discordUser.Id, discordUser.Username);
                CharacterPriorities characterPriorities = new(PressGangContext, user);
                Queue<string> response = characterPriorities.Farm();
                await DiscordUtils.Respond(ctx, response);
            }
            catch (Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
            }
        }


        [Command("campaign")]
        public async Task CampaignCommand(CommandContext ctx)
        {
            DiscordMember discordUser = ctx.Member;
            ShoppingList shoppingList = new(PressGangContext, discordUser.Id, discordUser.Username);
            try
            {
                Queue<string> response = shoppingList.DisplayOpportunities(LocationType.CampaignNode);
                await DiscordUtils.Respond(ctx, response);
            }
            catch (Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
            }
        }
    }
}
