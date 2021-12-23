using System;
using System.Collections.Generic;
using System.Linq;
using PressGang.Core.DatabaseContext;
using PressGang.Core.UserModels;
using PressGang.Core.StaticModels;

namespace PressGang.Core
{
    public class ShoppingList
    {
        private readonly PressGangContext _context;
        private readonly User _user;
        private List<Priority> _priorities;

        public ShoppingList(PressGangContext context, ulong discordId, string userName)
        {
            _context = context;
            User user;
            try
            {
                user = context.Users.First(u => u.DiscordId == discordId);
            }
            catch(InvalidOperationException)
            {
                user = new(discordId, userName);
                context.Add(user);
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

        public string DisplayOpportunities(LocationType locationType, string locationName = null)
        {
            List<Opportunity> opportunityList = ListOpportunities(locationType, locationName);
            string result = "Character shard priorities\r\n";
            int lineNumber = 0;
            foreach (Opportunity opportunity in opportunityList)
            {
                lineNumber++;
                result += String.Format("{0}. {1}\r\n", lineNumber.ToString(), opportunity.ToString());
            }
            return result;
        }


        private Dictionary<int, List<Opportunity>> LoadOpportunities()
        {
            Dictionary<Resource, int> priorityList = LoadPriorities();
            Dictionary<int, List<Opportunity>> opportunityList = new();

            foreach (Opportunity opportunity in _context.Opportunties)
            {
                if (opportunity.Resource != null)
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
            }
            return opportunityList;

        }
        
        public string DisplayPriorities()
        {
            Dictionary<Resource, int> priorityList = LoadPriorities();
            string result = "Character - Priority\r\n";
            foreach (KeyValuePair<Resource, int> kvp in priorityList)
            {
                result += String.Format("{0} - {1}\r\n", kvp.Key.Name, kvp.Value.ToString());
            }
            return result;
        }

        private Dictionary<Resource, int> LoadPriorities()
        {
            Dictionary<Resource, int> priorityList = new();
            foreach (Priority priority in _context.Priorities.Where<Priority>(p => p.User == _user))
            {
                if (priority.Resource != null)
                {
                    priorityList.Add(priority.Resource, priority.PriorityLevel);
                }
            }
            return priorityList;
        }

    }
}
