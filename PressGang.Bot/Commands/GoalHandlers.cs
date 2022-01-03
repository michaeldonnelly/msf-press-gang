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
    [Aliases("goal")]
    public class GoalHandlers : HandlerCore
    {
        public PressGangContext PressGangContext { private get; set; }

        public GoalHandlers(IOptions<DiscordOptions> options) : base(options)
        { }

        [Command("list")]
        public async Task ListCommand(CommandContext ctx)
        {
            Console.WriteLine("list");
            DiscordMember discordUser = ctx.Member;
            User user = LookUp.User(PressGangContext, discordUser.Id, discordUser.Username);
            List<YellowStarGoal> yellowStarGoals = user.YellowStarGoals;
            List<IPressGangRecord> goals = new(yellowStarGoals);
            Queue<string> response = new();
            Core.Reports.Format.AddListToQueue(goals, ref response, bullets: true);
            await DiscordUtils.Respond(ctx, response);
        }

        [Command("add")]
        public async Task AddCommand(CommandContext ctx, string characterName)
        {
            Console.WriteLine("add");
            try
            {
                DiscordMember discordUser = ctx.Member;
                User user = LookUp.User(PressGangContext, discordUser.Id, discordUser.Username);
                Character character = LookUp.Character(PressGangContext, characterName);
                GoalOperations.AddYellowStarGoal(PressGangContext, user, character);

                string response = "Added " + character.Name;
                await DiscordUtils.Respond(ctx, response);
            }
            catch (Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
            }

        }
    }
}
