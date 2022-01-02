using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DatabaseOperations;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

namespace PressGang.Core.Reports
{
    public static class StaticReports
    {
        public static List<string> Unlocks(PressGangContext context, Character character, int unlockAt,
            out int yellowStars, out bool hasRequiredChars, out int? characterLevel, out int? gearTier, out int? iso8ClassLevel)
        {
            if (unlockAt < character.MinimumUnlockStars)
            {
                throw new Exception($"{character.Name} opens at {character.MinimumUnlockStars} yellow stars");
            }

            // Add prerequisite characters
            hasRequiredChars = false;
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
                response.Add(characterName);
            }
            response.Sort();

            // Add prerequisite stats (though generally yellowStars will be the only one
            yellowStars = unlockAt;
            PrerequisiteStats prerequisiteStats = LookUp.PrerequisiteStats(context, character, unlockAt);
            if (prerequisiteStats != null)
            {
                characterLevel = prerequisiteStats.CharacterLevel;
                gearTier = prerequisiteStats.GearTier;
                iso8ClassLevel = prerequisiteStats.Iso8ClassLevel;
            }
            else
            {
                characterLevel = null;
                gearTier = null;
                iso8ClassLevel = null;
            }

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
