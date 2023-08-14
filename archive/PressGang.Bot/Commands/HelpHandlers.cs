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
        [Description("Say hi to the bot (it's friendly)")]
        public async Task GreetCommand(CommandContext ctx)
        {
            DiscordMember discordMember = ctx.Member;
            await DiscordUtils.Respond(ctx, "Greetings " + discordMember.Username);
        }

        [Command("info")]
        [Description("Whose bot is this?")]
        public async Task InfoCommand(CommandContext ctx)
        {
            string botName = _options.BotName;
            string allianceName = _options.AllianceName;
            string response = $"Hi I'm {botName}, the alliance support bot for {allianceName}.  You can find my source code at https://github.com/michaeldonnelly/msf-press-gang";
            await DiscordUtils.Respond(ctx, response);
        }
    }
}
