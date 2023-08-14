using System;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;
using PressGang.Core.DatabaseContext;
using System.Collections.Generic;
using PressGang.Core.Reports;
using System.Linq;

namespace PressGang.Core.DatabaseOperations
{
    public static class GoalOperations
    {
        public static void AddYellowStarGoal(PressGangContext context, User user, Character character, bool top = false, int? priority = null)
        {
            RemoveYellowStarGoal(context, user, character);
            YellowStarGoal yellowStarGoal = new(user, character);
            SortedDictionary<int, IGoal> dictionary = GoalDict(context, user);
            AddGoal(context, dictionary, yellowStarGoal, top, priority);
        }

        public static void RemoveYellowStarGoal(PressGangContext context, User user, Character character)
        {
            YellowStarGoal goaltoRemove = FindExistingGoal(context, user, character);
            if (goaltoRemove != null)
            {
                SortedDictionary<int, IGoal> dictionary = GoalDict(context, user);
                RemoveGoal(context, dictionary, goaltoRemove);
            }
        }

        private static YellowStarGoal FindExistingGoal(PressGangContext context, User user, Character character)
        {
            return context.YellowStarGoals.Where(g =>
                g.User == user &
                g.Character == character
            ).FirstOrDefault();
        }

        private static SortedDictionary<int, IGoal> GoalDict(PressGangContext context, User user)
        {
            List<YellowStarGoal> yellowStarGoals = user.YellowStarGoals;
            List<IGoal> goals = new(yellowStarGoals);
            SortedDictionary<int, IGoal> dictionary;
            try
            {
                dictionary = GoalReports.GoalListToDictionary(goals);
            }
            catch(ArgumentException)
            {
                CleanupGoals(context, goals);
                dictionary = GoalReports.GoalListToDictionary(goals);
            }
            return dictionary;
        }

        private static void AddGoal(PressGangContext context, SortedDictionary<int, IGoal> goals, IGoal goal, bool top = false, int? priority = null)
        {
            if (top)
            {
                priority = 1;
            }
            else if (priority == null)
            {
                priority = goals.Count + 1;
            }

            for (int position = (int)priority; position <= goals.Count; position++)
            {
                goals[position].Priority += 1;
                context.Update(goals[position]);
            }

            goal.Priority = (int)priority;
            context.Add(goal);
            context.SaveChanges();
        }

        private static void RemoveGoal(PressGangContext context, SortedDictionary<int, IGoal> goals, IGoal goalToRemove)
        {
            for (int position = goalToRemove.Priority + 1; position <= goals.Count; position++)
            {
                goals[position].Priority -= 1;
                context.Update(goals[position]);
            }
            context.Remove(goalToRemove);
            context.SaveChanges();
        }

        public static void CleanupGoals(PressGangContext context, List<IGoal> goals)
        {
            IGoal[] goalArray = goals.OrderBy(g => g.Priority).ToArray();
            int priority = 0;
            for (int i = 0; i < goalArray.Length; i++)
            {
                priority++;
                IGoal entry = goalArray[i];
                if (entry.Priority != priority)
                {
                    entry.Priority = priority;
                    context.Update(entry);
                }
            }

            context.SaveChanges();
        }
    }
}
