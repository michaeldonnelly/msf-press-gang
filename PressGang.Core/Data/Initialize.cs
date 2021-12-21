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


            //CharacterPriorityList foo = new();
            //foo.Characters.Add(cable.Id, 10);
            //foo.Characters.Add(yondu.Id, 10);
            //foo.Characters.Add(ultimateSpidey.Id, 99);
            ////foo.Characters.Add(30, danvers);

            //List<Opportunity> shoppingList = foo.ShoppingList(context);

            string bar = "";
            int lineNumber = 0;
            foreach (Opportunity o in shoppingList)
            {
                lineNumber++;
                bar += String.Format("{0}. {1}\r\n", lineNumber.ToString(), o.ToString());
            }
            return bar;
        }

    }
}
