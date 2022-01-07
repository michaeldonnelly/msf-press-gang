using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DatabaseOperations;
using PressGang.Core.Reports;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;
using PressGang.Core.ViewModels;

namespace PressGang.Test.ViewModelsTest
{
    [TestClass]
    public class ShoppingListTest
    {
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            var keepalive = InMemoryDatabase.RawSqliteConnection();
            keepalive.Open();
            InMemoryDatabase.InitializeContext();
        }

        private static void InitGoals()
        {
            PressGangContext context = InMemoryDatabase.GetContext();

        }

        [TestMethod]
        public void DailyObjectives()
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            User user = context.Users.Where(u => u.UserName == "Hawkshaw").FirstOrDefault();
            Assert.IsNotNull(user);

            Character bucky = LookUp.Character(context, "Bucky");
            GoalOperations.AddYellowStarGoal(context, user, bucky);
            ShoppingList shoppingList = new(context, user);

            Opportunity opportunity = shoppingList.Heroes();
            AssertOpportunity(opportunity, bucky, "Heroes");
            
        }

        private void AssertOpportunity(Opportunity opportunity, Character character, string campaignName)
        {
            Assert.AreEqual(campaignName, opportunity.Location.Campaign.NickName);
            Assert.AreSame(character, opportunity.Resource.Character);
        }


    }
}
