using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Microsoft.Extensions.Options;

namespace PressGang.Bot.Commands
{
    public class AdminHandlers : HandlerCore
    {
        public AdminHandlers(IOptions<DiscordOptions> options) : base(options)
        { }

        [Command("ping")]
        [Description("Confirm that the bot is up and running")]
        public async Task PingCommand(CommandContext ctx)
        {
            await DiscordUtils.Respond(ctx, "ack");
        }

        [Command("wait")]
        [RequireOwner]
        [Description("Sleep for while")]
        public async Task WaitCommand(CommandContext ctx, int milliseconds)
        {
            Thread.Sleep(milliseconds);
            string response = String.Format("Waited for {0} seconds", (milliseconds / 1000).ToString());
            await DiscordUtils.Respond(ctx, response);
        }


    }
}
