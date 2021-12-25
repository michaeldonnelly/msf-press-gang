using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace PressGang.Bot.Commands
{
    public class AdminHandlers : BaseCommandModule
    {
        public DiscordOptions DiscordOptions { set; private get; }

        [Command("ping")]
        public async Task PingCommand(CommandContext ctx)
        {
            await DiscordUtils.Respond(ctx, "ack");
        }



    }
}
