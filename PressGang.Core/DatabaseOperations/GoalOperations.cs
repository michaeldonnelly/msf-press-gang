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
            YellowStarGoal yellowStarGoal = new(user, character);
            SortedDictionary<int, IGoal> dictionary = GoalDict(context, user);
            AddGoal(context, dictionary, yellowStarGoal, top, priority);
        }

        private static SortedDictionary<int, IGoal> GoalDict(PressGangContext context, User user)
        {
            List<YellowStarGoal> yellowStarGoals = user.YellowStarGoals;
            List<IGoal> goals = new(yellowStarGoals);
            SortedDictionary<int, IGoal> dictionary = GoalReports.GoalListToDictionary(goals);
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

        public static void RemoveYellowStarGoal(PressGangContext context, User user, Character character)
        {
            List<YellowStarGoal> goals = context.YellowStarGoals.Where(g =>
                g.User == user &
                g.Character == character
            ).ToList();

            foreach(YellowStarGoal entry in goals)
            {
                context.Remove(entry);
            }
            context.SaveChanges();


        }






    }
}
