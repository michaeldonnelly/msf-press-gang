using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using PressGang.Core;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DatabaseOperations;
using PressGang.Core.Reports;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

namespace PressGang.Bot.Commands
{
    public class WantListHandler : HandlerCore
    {

        public PressGangContext PressGangContext { private get; set; }

        public WantListHandler(IOptions<DiscordOptions> options) : base(options)
        { }
      
    }
}
