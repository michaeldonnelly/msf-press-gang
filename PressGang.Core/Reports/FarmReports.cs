using System;
using System.Collections.Generic;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DynamicModels;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

namespace PressGang.Core.Reports
{
    public static class FarmReports
    {
        public static List<Farm> Farms(PressGangContext context, List<IGoal> goals)
        {
            List<Farm> farms = new();
            foreach (IGoal goal in goals)
            {
                AddGoalToFarmList(context, goal, ref farms);
            }
            return farms;
        }

        public static void AddGoalToFarmList(PressGangContext context, IGoal goal, ref List<Farm> farms)
        {
            int priority = goal.Priority;
            Resource resource = goal.Resource(context);
            foreach (Opportunity opportunity in resource.Opportunities)
            {
                Farm farm = new(priority, resource, opportunity);
                farms.Add(farm);
            }
        }
    }
}
