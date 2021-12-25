using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Microsoft.Extensions.Options;

namespace PressGang.Bot.Commands
{
    public class HelpHandlers : HandlerCore
    {
        public HelpHandlers(IOptions<DiscordOptions> options) : base(options)
        { }

        [Command("hello")]
        public async Task GreetCommand(CommandContext ctx)
        {
            DiscordMember discordMember = ctx.Member;
            await DiscordUtils.Respond(ctx, "Greetings " + discordMember.Username);
        }

        [Command("info")]
        public async Task InfoCommand(CommandContext ctx)
        {
            string botName = _options.BotName;
            string response = String.Format("Hi I'm {0}, the alliance support bot for {1}.", botName, "foo");
            await DiscordUtils.Respond(ctx, response);
        }
    }
}
