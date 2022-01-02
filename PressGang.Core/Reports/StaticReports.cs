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
            foreach (PrerequisiteCharacter prerequisite in character.PrerequisiteCharacters)
            {
                context.Entry(prerequisite).Reference("DependsOn").Load();
                dependsOn.Add(prerequisite.DependsOn);
            }
            return dependsOn;
        }

        public static List<string> Unlocks(PressGangContext context, Character character, int unlockAt,
            out int yellowStars, out bool hasRequiredChars, out int? characterLevel, out int? gearTier, out int? iso8ClassLevel)
        {
            if (unlockAt < character.MinimumUnlockStars)
            {
                throw new Exception($"{character.Name} opens at {character.MinimumUnlockStars} yellow stars");
            }

            hasRequiredChars = false;
            yellowStars = 0;

            List<string> response = new();
            foreach (PrerequisiteCharacter prerequisite in character.PrerequisiteCharacters)
            {
                context.Entry(prerequisite).Reference("DependsOn").Load();
                string characterName = prerequisite.DependsOn.Name;

                if (prerequisite.Required)
                {
                    hasRequiredChars = true;
                    characterName += " *";
                }

                if (prerequisite.RequiredYellowStars > yellowStars)
                {
                    yellowStars = prerequisite.RequiredYellowStars;
                }
                response.Add(characterName);
            }

            characterLevel = character.PrerequisiteCharacters[0].RequiredCharacterLevel;
            gearTier = character.PrerequisiteCharacters[0].RequiredGearTier;
            iso8ClassLevel = character.PrerequisiteCharacters[0].RequiredIso8ClassLevel;
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
