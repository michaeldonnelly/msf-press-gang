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
        public async Task AddCommand(CommandContext ctx, params string[] args)
        {
            string characterName;
            int unlockAt = 0;

            if (Int32.TryParse(args[0], out unlockAt))
            {
                characterName = String.Join(" ", args, 1, args.Length - 1);
            }
            else
            {
                characterName = String.Join(" ", args);
            }

            try
            {
                Queue<string> response = Unlock(characterName, unlockAt);
                await DiscordUtils.Respond(ctx, response);
            }
            catch (Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
            }
        }

        private Queue<string> Unlock (string characterName, int unlockAt)
        {
            Queue<string> response = new();

            Character character = LookUp.Character(PressGangContext, characterName);
            if (character == null)
            {
                response.Enqueue("Not found: " + characterName);
                return response;
            }

            if (unlockAt == 0)
            {
                unlockAt = (int)character.MinimumUnlockStars;   // Safe because every legendary has a minimum unlock
            }
            else if (unlockAt < character.MinimumUnlockStars)
            {
                response.Enqueue($"The minimum unlock for {character.Name} is {character.MinimumUnlockStars} stars");
                return response;
            }

            List<string> dependsOn = StaticReports.Unlocks(PressGangContext, character, out int yellowStars,
                out bool hasRequiredChars, out int? characterLevel, out int? gearTier, out int? iso8ClassLevel);
            if (dependsOn.Count == 0)
            {
                response.Enqueue($"{character.Name} is not a legendary unlock (or my data are out of date)");
                return response;
            }
            else
            {
                string header = $"To unlock {character.Name} you will need 5 of the following at {yellowStars} yellow stars";
                if (characterLevel != null) { header += $" + level {characterLevel}"; }
                if (gearTier != null) { header += $" + gear tier {gearTier}"; }
                if (iso8ClassLevel != null) { header += $" + ISO-8 class level {iso8ClassLevel}"; }

                response.Enqueue(header);
                foreach (string prereq in dependsOn)
                {
                    response.Enqueue($"  - {prereq}");
                }
                if (hasRequiredChars)
                {
                    response.Enqueue("\r\n    * = required");
                }
                return response;
            }
            

        }
    }
}
