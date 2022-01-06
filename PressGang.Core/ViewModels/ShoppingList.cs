using System;
using System.Collections.Generic;
using PressGang.Core.DatabaseContext;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

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
        }

        private List<IGoal> Goals;

        public List<Opportunity> Farm(LocationType locationType)
        {
            List<Opportunity> farm = new();
            return farm;
        }

        /// <summary>
        /// Get the shard the user wants most from the Heroes campaign
        /// </summary>
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
