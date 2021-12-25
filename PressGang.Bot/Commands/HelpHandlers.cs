using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Microsoft.Extensions.Options;

namespace PressGang.Bot.Commands
{
    public class HelpHandlers : BaseCommandModule
    {
        private readonly DiscordOptions _options;

        public HelpHandlers(IOptions<DiscordOptions> options)
        {
            _options = options.Value;
        }

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
