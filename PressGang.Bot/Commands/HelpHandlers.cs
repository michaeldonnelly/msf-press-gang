using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PressGang.Bot;

namespace PressGang.Bot.Commands
{
    public class HelpHandlers : BaseCommandModule
    {
        //public DiscordOptions DiscordOptions { set; private get; }
        private readonly IConfiguration _configuration;
        private readonly DiscordOptions _options;

        private DiscordOptions Options()
        {
            DiscordOptions discordOptions = new DiscordOptions();
            _configuration.GetSection(DiscordOptions.Discord).Bind(discordOptions);
            return discordOptions;
        }

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
