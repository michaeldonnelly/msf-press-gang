using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PressGang.Core.DatabaseContext;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

namespace PressGang.Core.Reports
{
    public static class GoalReports
    {
        public static Dictionary<int, IGoal> GoalListToDictionary(List<IGoal> list)
        {
            Dictionary<int, IGoal> dictionary = new();
            foreach (IGoal entry in list)
            {
                dictionary.Add(entry.Priority, entry);
            }
            return dictionary;
        }
    }
}
