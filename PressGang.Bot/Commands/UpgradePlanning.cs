﻿using System;
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
using PressGang.Core.Data;
using PressGang.Core.StaticModels;


// 559173272306974740
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

                Queue<string> response2 = new();
                response2.Append("**List of " + tableName + "**");
                foreach(var entry in set)
                {
                    response2.Enqueue(entry.ToString());
                }

                Respond(ctx, response2);
            }
            catch (Exception ex)
            {
                HandleError(ctx, ex);
            }
        }

        private async void Respond(CommandContext ctx, Queue<string> responseQueue)
        {
            string responseString = "";
            while (responseQueue.Count > 0)
            {
                string line = responseQueue.Dequeue();
                if (responseString.Length + line.Length > 1800)
                {
                    await ctx.RespondAsync(responseString);
                    responseString = "";
                }
                responseString += line;
                responseString += "\r\n";
            }

            await ctx.RespondAsync(responseString);
        }


        [Command("db")]
        public async Task DbCommand(CommandContext ctx)
        {
            // TODO: restrict to owner
            string response = "Database status\r\n";
            try
            {
                response += "CanConnect: " + PressGangContext.Database.CanConnect().ToString() + "\r\n";
                response += "ProviderName: " + PressGangContext.Database.ProviderName.ToString() + "\r\n";

                response += "Record counts\r\n";
                response += String.Format("\t{0}: {1}\r\n", "Characters", PressGangContext.Characters.Count().ToString());
                response += String.Format("\t{0}: {1}\r\n", "Resources", PressGangContext.Resources.Count().ToString());
                response += String.Format("\t{0}: {1}\r\n", "Locations", PressGangContext.Locations.Count().ToString());
                response += String.Format("\t{0}: {1}\r\n", "Opportunties", PressGangContext.Opportunties.Count().ToString());
                response += String.Format("\t{0}: {1}\r\n", "Priorities", PressGangContext.Priorities.Count().ToString());


                IEnumerable<IEntityType> entityTypes = PressGangContext.Model.GetEntityTypes();
                foreach (IEntityType entityType in entityTypes)
                {
                    response += entityType.DisplayName() + "\r\n";
                }


                await ctx.RespondAsync(response);
            }
            catch (Exception ex)
            {
                HandleError(ctx, ex);
            }

        }



        [Command("my")]
        public async Task MyCommand(CommandContext ctx)
        {
            DiscordMember discordUser = ctx.Member;
            ShoppingList shoppingList = new(PressGangContext, discordUser.Id, discordUser.Username);

            //Character cap = PressGangContext.Characters.First(c => c.Name == "Captain America");
            //shoppingList.AddCharacter(cap, 10);



            string response = shoppingList.DisplayPriorities();
            await ctx.RespondAsync(response);
        }


        [Command("campaign")]
        public async Task CampaignCommand(CommandContext ctx)
        {
            DiscordMember discordUser = ctx.Member;
            ShoppingList shoppingList = new(PressGangContext, discordUser.Id, discordUser.Username);
            //Character cap = PressGangContext.Characters.First(c => c.Name == "Captain America");
            //shoppingList.AddCharacter(cap, 10);
            //await ctx.RespondAsync(shoppingList.DisplayOpportunities(LocationType.CampaignNode));
            try
            {
                string response = shoppingList.DisplayOpportunities(LocationType.CampaignNode);
                await ctx.RespondAsync(response);
            }
            catch (Exception ex)
            {
                HandleError(ctx, ex);
            }
        }

        private void HandleError(CommandContext ctx, Exception ex)
        {
            if (ctx.User.Id == 559173272306974740)
            {
                ctx.RespondAsync(ex.ToString());
            }
            else
            {
                // TODO: log errors
            }
        }

    }

}
