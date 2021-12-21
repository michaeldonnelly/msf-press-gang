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

            LoadPriorities();
        }

        private void LoadPriorities()
        {
            _priorities = _context.Priorities.Where<Priority>(p => p.User == _user).ToList<Priority>();
        }

        public void RemoveCharacter(Character character)
        {
            //Resource shard = 
        }



    }
}
