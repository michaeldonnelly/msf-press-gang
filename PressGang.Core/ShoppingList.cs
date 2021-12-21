using System;
using System.Linq;
using PressGang.Core.Data;
using PressGang.Core.DynamicModels;

namespace PressGang.Core
{
    public class ShoppingList
    {
        private readonly PressGangContext _context;
        private readonly User _user;
        private CharacterPriorityList _characterPriorityList;

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

            CharacterPriorityList characterPriorityList;
            //try
            //{
            //    characterPriorityList = 
            //}



        }


    }
}
