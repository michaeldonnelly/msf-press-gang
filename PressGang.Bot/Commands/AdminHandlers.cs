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
        public async Task PingCommand(CommandContext ctx)
        {
            await DiscordUtils.Respond(ctx, "ack");
        }

        [Command("wait")]
        public async Task WaitCommand(CommandContext ctx, int milliseconds)
        {
            string response;
            if (CallerIsOwner(ctx))
            {
                Thread.Sleep(milliseconds);
                response = String.Format("Waited for {0} seconds", (milliseconds / 1000).ToString());
            }
            else
            {
                response = "You're not the boss of me.";
            }
            await DiscordUtils.Respond(ctx, response);
        }


    }
}
