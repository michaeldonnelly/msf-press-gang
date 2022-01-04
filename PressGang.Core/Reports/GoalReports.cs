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
        public static SortedDictionary<int, IGoal> GoalListToDictionary(List<IGoal> list)
        {
            SortedDictionary<int, IGoal> dictionary = new();
            foreach (IGoal entry in list)
            {
                dictionary.Add(entry.Priority, entry);
            }

            return dictionary;
        }

        public static void GoalsToQueue(List<IGoal> goalsList, ref Queue<string> queue, bool numbered = true)
        {
            SortedDictionary<int, IGoal> goalsDict = GoalListToDictionary(goalsList);
            foreach (var entry in goalsDict)
            {
                IGoal goal = entry.Value;
                string line;
                if (numbered)
                {
                    line = $" {goal.Priority}. {goal.Name}";
                }
                else
                {
                    line = goal.Name;
                }
                queue.Enqueue(line);
            }
        }
    }
}
