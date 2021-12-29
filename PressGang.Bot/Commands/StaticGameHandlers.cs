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

namespace PressGang.Bot.Commands
{
    public class StaticGameHandlers : HandlerCore
    {
        public PressGangContext PressGangContext { private get; set; }

        public StaticGameHandlers(IOptions<DiscordOptions> options) : base (options)
        {
        }

        [Command("unlock")]
        [Aliases("prereq", "ul")]
        [Description("List the prerequisites for a character's legendary unlock event")]
        public async Task AddCommand(CommandContext ctx, string characterName, string c2 = null, string c3 = null)
        {
            //TODO: handle arbitrary parameters rather than this garbage
            if (!String.IsNullOrWhiteSpace(c2))
            {
                characterName += " " + c2;
                if (!String.IsNullOrWhiteSpace(c3))
                {
                    characterName += " " + c3;
                }
            }

            try
            {
                Character character = LookUp.Character(PressGangContext, characterName);
                if (character == null)
                {
                    string response = "Not found: " + characterName;
                    await DiscordUtils.Respond(ctx, response);
                }
                else
                {
                    List<string> dependsOn = StaticReports.Unlocks(PressGangContext, character, out int yellowStars, out bool hasRequiredChars);
                    if (dependsOn.Count == 0)
                    {
                        string response = $"{character.Name} is not a legendary unlock (or my data are out of date)";
                        await DiscordUtils.Respond(ctx, response);
                    }
                    else
                    {
                        Queue<string> response = new();
                        response.Enqueue($"To unlock {character.Name} you will need 5 of the following at {yellowStars} yellow stars:");
                        foreach (string prereq in dependsOn)
                        {
                            response.Enqueue($"  - {prereq}");
                        }
                        if (hasRequiredChars)
                        {
                            response.Enqueue("\r\n    * = required");
                        }
                        await DiscordUtils.Respond(ctx, response);
                    }
                }
            }
            catch (Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
            }
        }
    }
}
