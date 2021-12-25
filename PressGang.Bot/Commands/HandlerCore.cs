using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Microsoft.Extensions.Options;

namespace PressGang.Bot.Commands
{
    public abstract class HandlerCore : BaseCommandModule
    {
        protected readonly DiscordOptions _options;

        public HandlerCore(IOptions<DiscordOptions> options)
        {
            _options = options.Value;
        }

    }
}
