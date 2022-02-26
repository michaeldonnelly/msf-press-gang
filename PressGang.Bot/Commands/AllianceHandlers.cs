using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Microsoft.Extensions.Options;

namespace PressGang.Bot.Commands
{
    public class AllianceHandlers : HandlerCore
    {
        public AllianceHandlers(IOptions<DiscordOptions> options) : base(options)
        { }

        [Command("lanes")]
        [Description("Display raid lane maps")]
        [Aliases("lane")]
        public async Task LanesCommand(CommandContext ctx,
            [Description("Which raid; leave blank for all")] string raid = "all",
            [Description("Which level of the raid; leave blank for all")] int level = 0)
        {
            List<RaidLane> raidLanes = _options.AllianceData.Maps.RaidLanes.Where(rl => RaidLaneMatchesQuery(rl, raid, level)).ToList();
            if (raidLanes.Count == 0)
            {
                string response = "We don't have that lane defined yet. Try searching less specifically (i.e. leave out the level number).";
                await DiscordUtils.Respond(ctx, response);
            }
            else
            {
                foreach (RaidLane lane in raidLanes)
                {
                    string response = $"{_options.AllianceName} raid lanes for {lane.Raid}";
                    if (lane.Level > 0)
                    {
                        response += $" level {lane.Level}";
                    }

                    if (lane.IsImage)
                    {
                        await DiscordUtils.RespondImage(ctx, response, lane.Url);
                    }
                    else
                    {
                        await DiscordUtils.Respond(ctx, response, lane.Url);
                    }
                }
            }
        }

        private bool RaidLaneMatchesQuery(RaidLane raidLane, string raid, int level)
        {
            if (raid == "all")
            {
                return true;
            }

            if (raid != raidLane.Raid)
            {
                return false;
            }

            if (level == 0)
            {
                return true;
            }

            return (level == raidLane.Level);
        }


    }
}
