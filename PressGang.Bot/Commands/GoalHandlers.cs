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
    [Group("goals")]
    [Aliases("goal", "g")]
    public class GoalHandlers : HandlerCore
    {
        public PressGangContext PressGangContext { private get; set; }

        public GoalHandlers(IOptions<DiscordOptions> options) : base(options)
        { }

        [Command("list")]
        [Aliases("ls")]
        public async Task ListCommand(CommandContext ctx)
        {
            await ListGoals(ctx, false);
        }

        [Command("farm")]
        [Aliases("f")]
        public async Task FarmCommand(CommandContext ctx)
        {
            await ListGoals(ctx, true);
        }

        private async Task ListGoals(CommandContext ctx, bool farm)
        { 
            try
            {
                DiscordMember discordUser = ctx.Member;
                User user = LookUp.User(PressGangContext, discordUser.Id, discordUser.Username);
                Queue<string> response = new();
                response.Enqueue($"Character goals for {user.UserName}");
                AddGoalsToQueue(user, ref response, farm);
                await DiscordUtils.Respond(ctx, response);
            }
            catch(Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
            }
        }

        private void AddGoalsToQueue(User user, ref Queue<string> queue, bool farm = false)
        {
            PressGangContext.Entry(user).Collection(u => u.YellowStarGoals).Load();
            List<YellowStarGoal> yellowStarGoals = user.YellowStarGoals;
            List<IGoal> goals = new(yellowStarGoals);
            GoalReports.GoalsToQueue(PressGangContext, goals, ref queue, farm: farm);
        }

        private void ParseParameters(string[] paramsString, out string characterName, out int? priority, out int? yellowStars, out bool top)
        {
            priority = null;
            yellowStars = null;
            top = false;

            List<string> paramsList = new(paramsString);
            List<string> modifiedParamsList = new List<string>(paramsList);
            foreach (string piece in paramsList)
            {
                if (int.TryParse(piece, out int p))
                {
                    priority = p;
                    modifiedParamsList.Remove(piece);
                    continue;
                }

                if (TryParseYellowStars(piece, out int ys))
                {
                    yellowStars = ys;
                    modifiedParamsList.Remove(piece);
                    continue;
                }

                if (piece.ToLower() == "top")
                {
                    top = true;
                    modifiedParamsList.Remove(piece);
                    continue;
                }
            }

            characterName = String.Join(" ", modifiedParamsList.ToArray());
        }

        private bool TryParseYellowStars(string s, out int yellowStars)
        {
            yellowStars = 0;

            if (s.Length != 3)
            {
                return false;
            }

            if (s.Substring(1,2).ToLower() != "ys")
            {
                return false;
            }

            string firstChar = s.Substring(0, 1);
            if (!int.TryParse(firstChar, out int result))
            {
                return false;
            }

            if (result > 7)
            {
                return false;
            }

            if (result < 1)
            {
                return false;
            }

            yellowStars = result;
            return true;
        }


        [Command("add")]
        public async Task AddCommand(CommandContext ctx, params string[] parameters)
        {
            try
            {
                ParseParameters(parameters, out string characterName, out int? priority, out int? yellowStars, out bool top);
                // TODO: actually use the yellow stars

                DiscordMember discordUser = ctx.Member;
                User user = LookUp.User(PressGangContext, discordUser.Id, discordUser.Username);
                Character character = LookUp.Character(PressGangContext, characterName);
                GoalOperations.AddYellowStarGoal(PressGangContext, user, character, top, priority);

                Queue<string> response = new();
                response.Enqueue("Added " + character.Name);
                response.Enqueue("\r\n");
                response.Enqueue("Your character goals are now");
                AddGoalsToQueue(user, ref response);
                await DiscordUtils.Respond(ctx, response);
            }
            catch (Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
            }
        }

        [Command("remove")]
        [Aliases("delete", "del", "rm")]
        public async Task RemoveCommand(CommandContext ctx, [RemainingText] string characterName)
        {
            try
            {
                DiscordMember discordUser = ctx.Member;
                User user = LookUp.User(PressGangContext, discordUser.Id, discordUser.Username);
                Character character = LookUp.Character(PressGangContext, characterName);
                GoalOperations.RemoveYellowStarGoal(PressGangContext, user, character);
                Queue<string> response = new();
                response.Enqueue("Removed " + character.Name);
                response.Enqueue("\r\n");
                response.Enqueue("Your character goals are now");
                AddGoalsToQueue(user, ref response);
                await DiscordUtils.Respond(ctx, response);
            }
            catch (Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
            }
        }
    }
}
