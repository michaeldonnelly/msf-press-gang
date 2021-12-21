using System;
using System.Collections.Generic;
using System.Linq;
using PressGang.Core.Data;
using PressGang.Core.DynamicModels;
using PressGang.Core.StaticModels;

namespace PressGang.Core
{
    public class ShoppingList
    {
        private readonly PressGangContext _context;
        private readonly User _user;
        private List<Priority> _priorities;

        public ShoppingList(PressGangContext context, int userId)
        {
            _context = context;
            User user;
            try
            {
                user = context.Users.First(u => u.Id == userId);
            }
            catch(InvalidOperationException)
            {
                user = new()
                {
                    Id = userId
                };
                context.SaveChanges();
            }
        }


        public void RemoveCharacter(Character character)
        {
            Priority priority = FindCharacterPriority(character);
            if (priority != null)
            {
                _context.Priorities.Remove(priority);
                _context.SaveChanges();
            }
        }

        public void AddCharacter(Character character, int priorityLevel)
        {
            Resource shard = LookUp.Shard(_context, character);
            Priority oldPriority = FindCharacterPriority(shard);
            if (oldPriority != null)
            {
                if (oldPriority.PriorityLevel == priorityLevel)
                {
                    return;
                }
                else
                {
                    _context.Priorities.Remove(oldPriority);
                }
            }

            Priority newPriority = new(_user, shard, priorityLevel);
            _context.Add(newPriority);
            _context.SaveChanges();
        }

        private Priority FindCharacterPriority(Character character)
        {
            Resource shard = LookUp.Shard(_context, character);
            return FindCharacterPriority(shard);
        }

        private Priority FindCharacterPriority(Resource shard)
        { 
            try
            {
                Priority priority = _context.Priorities.First(p =>
                    (p.User == _user)
                    && (p.Resource == shard)
                );
                return priority;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public List<Opportunity> ListOpportunities(LocationType locationType, string locationName = null)
        {
            Dictionary<int, List<Opportunity>> opportunityList = LoadOpportunities();
            List<Opportunity> shoppingList = new();
            foreach (KeyValuePair<int, List<Opportunity>> kvp in opportunityList.OrderBy(kvp => kvp.Key))
            {
                foreach (Opportunity opportunity in kvp.Value)
                {
                    Location location = opportunity.Location;
                    if (location.LocationType == locationType)
                    {
                        if (String.IsNullOrWhiteSpace(locationName) || location.Name == locationName)
                        {
                            shoppingList.Add(opportunity);
                        }
                    }
                }
            }
            return shoppingList;
        }


        public Dictionary<int, List<Opportunity>> LoadOpportunities()
        {
            Dictionary<Resource, int> priorityList = LoadPriorities();
            Dictionary<int, List<Opportunity>> opportunityList = new();

            foreach (Opportunity opportunity in _context.Opportunties)
            {
                if (priorityList.ContainsKey(opportunity.Resource))
                {
                    int priorityLevel = priorityList[opportunity.Resource];
                    if (opportunityList.ContainsKey(priorityLevel))
                    {
                        opportunityList[priorityLevel].Add(opportunity);
                    }
                    else
                    {
                        List<Opportunity> lo = new() { opportunity };
                        opportunityList.Add(priorityLevel, lo);
                    }
                }
            }
            return opportunityList;

        }

        private Dictionary<Resource, int> LoadPriorities()
        {
            Dictionary<Resource, int> priorityList = new();
            foreach (Priority priority in _context.Priorities.Where<Priority>(p => p.User == _user))
            {
                priorityList.Add(priority.Resource, priority.PriorityLevel);
            }
            return priorityList;
        }

    }
}
