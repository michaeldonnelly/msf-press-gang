using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PressGang.Core.StaticModels;
using PressGang.Core.DynamicModels;

namespace PressGang.Core.Data
{
    public static class Initialize
    {
        public static string System(PressGangContext context)
        {

            foreach (Opportunity opportunity in context.Opportunties)
            {
                Debug.WriteLine(opportunity.ToString());
            }

            Character cable = context.Characters.First(c => c.Name == "Cable");
            Character yondu = context.Characters.First(c => c.Name == "Yondu");
            Character ultimateSpidey = context.Characters.First(c => c.Name == "Spider-Man [Miles]");

            int userId = 999;
            ShoppingList shoppingList1 = new(context, userId);
            shoppingList1.AddCharacter(cable, 10);
            shoppingList1.AddCharacter(yondu, 10);
            shoppingList1.AddCharacter(ultimateSpidey, 99);

            List<Opportunity> shoppingList = shoppingList1.ListOpportunities(LocationType.CampaignNode);


            string bar = "Campaign\r\n----------------\r\n";
            bar += shoppingList1.DisplayOpportunities(LocationType.CampaignNode);
            bar += "\r\nStores\r\n----------------\r\n";
            bar += shoppingList1.DisplayOpportunities(LocationType.Store);

            //int lineNumber = 0;
            //foreach (Opportunity o in shoppingList)
            //{
            //    lineNumber++;
            //    bar += String.Format("{0}. {1}\r\n", lineNumber.ToString(), o.ToString());
            //}
            return bar;
        }

    }
}
