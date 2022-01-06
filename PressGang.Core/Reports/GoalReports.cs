using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DatabaseOperations;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;
using PressGang.Core.ViewModels;

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

        public static void GoalsToQueue(PressGangContext context, List<IGoal> goalsList, ref Queue<string> queue, bool numbered = true, bool farm = true)
        {
            SortedDictionary<int, IGoal> goalsDict;
            try
            {
                goalsDict = GoalListToDictionary(goalsList);
            }
            catch (ArgumentException)
            {
                GoalOperations.CleanupGoals(context, goalsList);
                goalsDict = GoalListToDictionary(goalsList);
            }
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
                if (farm)
                {                    
                    string farmAt = "";
                    Resource resource = goal.Resource(context);
                    context.Entry(resource).Collection(r => r.Opportunities).Load();
                    foreach (Opportunity opportunity in resource.Opportunities)
                    {
                        context.Entry(opportunity).Reference(o => o.Location).Load();
                        if (!String.IsNullOrWhiteSpace(farmAt))
                        {
                            farmAt += ", ";
                        }
                        farmAt += opportunity.Location.ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(farmAt))
                    {
                        line += $" => {farmAt}";
                    }
                }

                queue.Enqueue(line);
            }
        }
    }
}
