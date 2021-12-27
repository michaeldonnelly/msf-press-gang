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
using Microsoft.Extensions.Options;
using PressGang.Core;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DatabaseOperations;
using PressGang.Core.Reports;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;


namespace PressGang.Bot.Commands
{
    [Group("pressgang")]
    [Aliases("pg")]
    public class PressGangHandlers : HandlerCore 
    {
        public PressGangContext PressGangContext { private get; set; }

        public PressGangHandlers(IOptions<DiscordOptions> options) : base(options)
        { }

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
        [RequireOwner]
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
    }
}
