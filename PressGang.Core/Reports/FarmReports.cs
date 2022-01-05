using System;
using System.Collections.Generic;
using System.Linq;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DynamicModels;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

namespace PressGang.Core.Reports
{
    public static class FarmReports
    {
        //public static Queue<string> FarmList(List<Farm> farms, LocationType locationType)
        //{
        //    Queue<string> report = new();
        //    report.Enqueue("Location                    Farm for");
        //    report.Enqueue("-------------------------   -----------------------------------");
            
        //    foreach (Farm farm in farms)
        //    {
        //        Location location = farm.Opportunity.Location;
        //        if (location.LocationType == locationType)
        //        {
        //            string campaign = location.Campaign.Name;
        //            string node = location.
        //        }
        //    }

        //}

        public static List<Farm> Farms(PressGangContext context, List<IGoal> goals)
        {
            List<Farm> farms = new();
            foreach (IGoal goal in goals)
            {
                AddGoalToFarmList(context, goal, ref farms);
            }
            return farms;
        }

        private static void AddGoalToFarmList(PressGangContext context, IGoal goal, ref List<Farm> farms)
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
