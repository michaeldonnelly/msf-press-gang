﻿using System;
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
    [Group("goals")]
    [Aliases("goal")]
    public class GoalHandlers : HandlerCore
    {
        public PressGangContext PressGangContext { private get; set; }

        public GoalHandlers(IOptions<DiscordOptions> options) : base(options)
        { }

        [Command("list")]
        public async Task ListCommand(CommandContext ctx)
        {
            Console.WriteLine("list");
            DiscordMember discordUser = ctx.Member;
            User user = LookUp.User(PressGangContext, discordUser.Id, discordUser.Username);
            List<YellowStarGoal> yellowStarGoals = user.YellowStarGoals;
            List<IPressGangRecord> goals = new(yellowStarGoals);
            Queue<string> response = new();
            Core.Reports.Format.AddListToQueue(goals, ref response, bullets: true);
            await DiscordUtils.Respond(ctx, response);
        }

        private void ParseParameters(string[] paramsString, out string characterName, out int? priority, out int? yellowStars, out bool top)
        {
            priority = null;
            yellowStars = null;
            top = false;

            List<string> paramsList = new(paramsString);
            List<string> modifiedParamsList = new List<string>(paramsList);
            foreach (string piece in paramsList)
            {
                if (int.TryParse(piece, out int p))
                {
                    priority = p;
                    modifiedParamsList.Remove(piece);
                    continue;
                }

                if (TryParseYellowStars(piece, out int ys))
                {
                    yellowStars = ys;
                    modifiedParamsList.Remove(piece);
                    continue;
                }

                if (piece.ToLower() == "top")
                {
                    top = true;
                    modifiedParamsList.Remove(piece);
                    continue;
                }
            }

            characterName = String.Join(" ", modifiedParamsList.ToArray());
        }

        private bool TryParseYellowStars(string s, out int yellowStars)
        {
            yellowStars = 0;

            if (s.Length != 3)
            {
                return false;
            }

            if (s.Substring(1,2).ToLower() != "ys")
            {
                return false;
            }

            string firstChar = s.Substring(0, 1);
            if (!int.TryParse(firstChar, out int result))
            {
                return false;
            }

            if (result > 7)
            {
                return false;
            }

            if (result < 1)
            {
                return false;
            }

            yellowStars = result;
            return true;
        }


        [Command("add")]
        public async Task AddCommand(CommandContext ctx, params string[] parameters)
        {
            Console.WriteLine("add");
            try
            {
                ParseParameters(parameters, out string characterName, out int? priority, out int? yellowStars, out bool top);

                DiscordMember discordUser = ctx.Member;
                User user = LookUp.User(PressGangContext, discordUser.Id, discordUser.Username);
                Character character = LookUp.Character(PressGangContext, characterName);
                GoalOperations.AddYellowStarGoal(PressGangContext, user, character, top, priority);

                string response = "Added " + character.Name;
                await DiscordUtils.Respond(ctx, response);
            }
            catch (Exception ex)
            {
                await DiscordUtils.HandleError(ctx, ex);
            }

        }
    }
}
