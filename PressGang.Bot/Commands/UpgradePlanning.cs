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
                IEnumerable set = default(IEnumerable);
                Type type = null;

                switch(subject)
                {
                    case "character":
                        set = PressGangContext.Characters;
                        type = typeof(Character);
                        break;
                    case "campaign":
                        set = PressGangContext.Campaigns;
                        type = typeof(Campaign);
                        break;
                }

                if (type == null)
                {
                    // TODO: tell the user we didn't find whatever it was
                }



                string response = "List of " + type.ToString() + "\r\n";
                foreach(var entry in set)
                {
                    response += entry.ToString() + "\r\n";
                }



                //foreach (Opportunity opportunity in PressGangContext.Opportunties.ToList<Opportunity>())
                //{
                //    response += opportunity.ToString() + "\r\n";
                //}
                await ctx.RespondAsync(response);
            }
            catch (Exception ex)
            {
                HandleError(ctx, ex);
            }


            //string response = "list";
            //if (subject != null)
            //{
            //    response += " " + subject;
            //}
            //await ctx.RespondAsync(response);

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
