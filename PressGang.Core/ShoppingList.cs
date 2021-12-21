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

        //public List<Opportunity> ListCampaignOpportunities(LocationType locationType)
        //{
             

        //}

        private Dictionary<int, List<Resource>> LoadResourceList()
        {
            Dictionary<int, List<Resource>> resourceList = new();
            foreach (Priority priority in _context.Priorities.Where<Priority>(p => p.User == _user))
            {
                if (resourceList.ContainsKey(priority.PriorityLevel))
                {
                    resourceList[priority.PriorityLevel].Add(priority.Resource);
                }
                else
                {
                    List<Resource> resources = new() { priority.Resource };
                    resourceList.Add(priority.PriorityLevel, resources);
                }
            }
            return resourceList;
        }

    }
}
