using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PressGang.Core.DatabaseContext;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

namespace PressGang.Core.Reports
{
    public static class StaticReports
    {
        public static List<Character> Prerequisites(PressGangContext context, Character character)
        {
            List<Character> dependsOn = new();
            foreach (Prerequisite prerequisite in character.Prerequisites)
            {
                context.Entry(prerequisite).Reference("DependsOn").Load();
                dependsOn.Add(prerequisite.DependsOn);
            }
            return dependsOn;
        }

        public static List<string> Unlocks(PressGangContext context, Character character, out int yellowStars, out bool hasRequiredChars)
        {
            hasRequiredChars = false;
            yellowStars = 0;

            List<string> response = new();
            foreach (Prerequisite prerequisite in character.Prerequisites)
            {
                context.Entry(prerequisite).Reference("DependsOn").Load();
                string characterName = prerequisite.DependsOn.Name;

                if (prerequisite.Required)
                {
                    hasRequiredChars = true;
                    characterName += " *";
                }

                if (prerequisite.YellowStars > yellowStars)
                {
                    yellowStars = prerequisite.YellowStars;
                }
                response.Add(characterName);
            }

            response.Sort();
            return response;
        }

        public static int RowsInTable(PressGangContext context, string tableName)
        {
            IEnumerable<object> set = (IEnumerable<object>)context.GetType().GetProperty(tableName).GetValue(context, null);
            int recordCount = set.Count();
            return recordCount;
        }
    }
}
