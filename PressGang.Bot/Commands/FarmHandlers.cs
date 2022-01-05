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
using PressGang.Core.DynamicModels;
using PressGang.Core.Reports;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

namespace PressGang.Bot.Commands
{
    [Group("farm")]
    public class FarmHandlers : HandlerCore
    {
        public PressGangContext PressGangContext { private get; set; }

        public FarmHandlers(IOptions<DiscordOptions> options) : base(options)
        { }

        [Command("shards")]
        [Aliases("shard", "character", "characters", "char")]
        public async Task ShardsCommand(CommandContext ctx)
        {
            try
            {
                DiscordMember discordUser = ctx.Member;
                User user = LookUp.User(PressGangContext, discordUser.Id, discordUser.Username);
                List<IGoal> goals = new(user.YellowStarGoals);
                List<Farm> farms = FarmReports.Farms(PressGangContext, goals);

                Queue<string> campaignFarms = new();
               

            }
            catch (Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
            }
        }


    }
}
