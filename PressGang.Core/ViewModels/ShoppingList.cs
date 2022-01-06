using System;
using System.Collections.Generic;
using PressGang.Core.DatabaseContext;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;
using System.Linq;

namespace PressGang.Core.ViewModels
{
    public class ShoppingList
    {
        private readonly PressGangContext Context;

        public User User { get; private set; }

        public ShoppingList(PressGangContext context, User user)
        {
            Context = context;
            User = user;
            Update();
        }

        private List<IGoal> Goals;

        private Dictionary<LocationType, Dictionary<Opportunity, int>> Opportunities;

        public void Update()
        {
            Opportunities = new();

            // Later, this will merge multiple kinds of goals
            Context.Entry(User).Collection(u => u.YellowStarGoals).Load();
            Goals = new(User.YellowStarGoals);
            foreach (IGoal goal in Goals)
            {
                Resource resource = goal.Resource(Context);
                Context.Entry(resource).Collection(r => r.Opportunities).Load();
                foreach (Opportunity opportunity in resource.Opportunities)
                {
                    Context.Entry(opportunity).Reference(o => o.Location).Load();
                    AddOpportunity(opportunity, goal.Priority);
                }
            }
        }

        private void AddOpportunity(Opportunity opportunity, int priority)
        {
            LocationType locationType = opportunity.Location.LocationType;
            if (Opportunities[locationType] == null)
            {
                Opportunities.Add(locationType, new Dictionary<Opportunity, int>());
            }
            Opportunities[locationType].Add(opportunity, priority);
        }        

        public List<Opportunity> Farm(LocationType locationType)
        {
            List<Opportunity> farm = new();
            return farm;
        }

        public Opportunity Heroes()
        {            
            return null;
        }

        /// <summary>
        /// Get the shard the user wants most from the Villains campaign
        /// </summary>
        public Opportunity Villains()
        {
            return null;
        }

        

    }
}
