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
                string tableName = TableName(subject);
                IEnumerable set = (IEnumerable)PressGangContext.GetType().GetProperty(tableName).GetValue(PressGangContext, null);

                string response = "List of " + tableName + "\r\n";
                foreach(var entry in set)
                {
                    response += entry.ToString() + "\r\n";
                }

                await ctx.RespondAsync(response);
            }
            catch (Exception ex)
            {
                HandleError(ctx, ex);
            }
        }

        private string FindTableInRelationalModel(IRelationalModel relationalModel, string subject = null, IEntityType entityType = null)
        {
            string tableName = null;
            foreach (ITable table in relationalModel.Tables)
            {
                if (
                    ((subject != null) && (table.Name.ToLower().Contains(subject)))
                   ||
                    ((entityType != null) && (EntityTypeForTable(table) == entityType))
                   )
                {
                    if (tableName != null)
                    {
                        // We already found a match
                        return null;
                    }

                    tableName = table.Name;
                }
            }

            return tableName;
        }

        private IEntityType EntityTypeForTable(ITable table)
        {
            IEnumerable<ITableMapping> entityTypeMapping = table.EntityTypeMappings;
            ITableMapping tableMapping = entityTypeMapping.First<ITableMapping>();
            return tableMapping.EntityType;
        }

        private IEntityType FindEntityType(IEnumerable<IEntityType> entityTypes, string subject)
        {
            IEntityType result = null;

            foreach (IEntityType entityType in entityTypes)
            {
                string entityName = entityType.DisplayName().ToLower();
                if (entityName.Contains(subject))
                {
                    if (result != null)
                    {
                        // The subject already matched on an EntityType
                        return null;
                    }

                    result = entityType;
                }
            }

            return result;
        }

       
        private string TableName(string subject)
        {
            IModel model = PressGangContext.Model;
            IRelationalModel relationalModel = model.GetRelationalModel();
            string tableName = FindTableInRelationalModel(relationalModel, subject: subject);
            if (tableName != null)
            {
                return tableName;
            }

            IEnumerable<IEntityType> entityTypes = model.GetEntityTypes();
            IEntityType entityType = FindEntityType(entityTypes, subject);
            if (entityType == null)
            {
                return null;
            }

            tableName = FindTableInRelationalModel(relationalModel, entityType: entityType);
            return tableName;
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
