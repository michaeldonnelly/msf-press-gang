using System;
using System.Threading;
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

        [Command("wait")]
        public async Task WaitCommand(CommandContext ctx, int milliseconds)
        {
            Thread.Sleep(milliseconds);
            string response = String.Format("Waited for {0} seconds", (milliseconds / 1000).ToString());
            await DiscordUtils.Respond(ctx, response);
        }


    }
}
