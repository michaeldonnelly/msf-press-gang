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
        public async Task AddCommand(CommandContext ctx, [Description("The name of the character and optionally the yellow star rank")]params string[] character)
        {
            string characterName;
            int unlockAt = 0;

            if (Int32.TryParse(character[0], out unlockAt))
            {
                characterName = String.Join(" ", character, 1, character.Length - 1);
            }
            else if (Int32.TryParse(character[character.Length - 1], out unlockAt))
            {
                characterName = String.Join(" ", character, 0, character.Length - 1);
            }
            else
            {
                characterName = String.Join(" ", character);
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

        [Command("legends")]
        [Aliases("legend")]
        [Description("List all the legendary characters who have special unlock events")]
        public async Task AddCommand(CommandContext ctx)
        {
            try
            {
                Queue<string> response = LegendaryCharacters();
                await DiscordUtils.Respond(ctx, response);
            }
            catch (Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
            }
        }

        private Queue<string> LegendaryCharacters()
        {
            List<IPressGangRecord> characters = StaticReports.LegendaryCharacters(PressGangContext);
            Queue<string> response = new();
            response.Enqueue("Legendary characters");
            PressGang.Core.Reports.Format.AddListToQueue(characters, ref response, bullets: true, sort: true);


            //List<string> names = new();
            //foreach (Character character in characters)
            //{
            //    names.Add(character.Name);
            //}
            //names.Sort();

            //Queue<string> response = new();
            //foreach (string name in names)
            //{
            //    response.Enqueue(" - " + name);
            //}
            return response;
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

            if (unlockAt > 7)
            {
                response.Enqueue($"You can't upgrade a character higher than 7 stars");
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

            List<string> dependsOn = StaticReports.Unlocks(PressGangContext, character, unlockAt, out int yellowStars,
                out bool hasRequiredChars, out int? characterLevel, out int? gearTier, out int? iso8ClassLevel);
            if (dependsOn.Count == 0)
            {
                response.Enqueue($"{character.Name} is not a legendary unlock (or my data are out of date)");
                return response;
            }

            string header = $"To unlock {character.Name} at {unlockAt} yellow stars you will need 5 of the following characters at {yellowStars} yellow stars";
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
