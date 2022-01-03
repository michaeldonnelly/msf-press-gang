using System;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;
using PressGang.Core.DatabaseContext;
using System.Collections.Generic;

namespace PressGang.Core.DatabaseOperations
{
    public static class GoalOperations
    {
        public static void AddYellowStarGoal(PressGangContext context, User user, Character character, bool top = false, int? priority = null)
        {
            YellowStarGoal yellowStarGoal = new(user, character);
            List<YellowStarGoal> yellowStarGoals = user.YellowStarGoals;
            List<IGoal> goals = new(yellowStarGoals);
            Dictionary<int, IGoal> dictionary = GoalListToDictionary(goals);
            AddGoal(context, dictionary, yellowStarGoal, top, priority);
        }

        public static Dictionary<int, IGoal> GoalListToDictionary(List<IGoal> list)
        {
            Dictionary<int, IGoal> dictionary = new();
            foreach (IGoal entry in list)
            {
                dictionary.Add(entry.Priority, entry);
            }
            return dictionary;
        }

        private static void AddGoal(PressGangContext context, Dictionary<int, IGoal> goals, IGoal goal, bool top = false, int? priority = null)
        {
            if (top)
            {
                priority = 1;
            }
            else if (priority == null)
            {
                priority = goals.Count + 1;
            }

            for (int position = (int)priority - 1; position <= goals.Count; position++)
            {
                goals[position].Priority += 1;
                context.Update(goals[position]);
            }

            goal.Priority = (int)priority;
            context.Add(goal);
            context.SaveChanges();
        }

        

    }
}
