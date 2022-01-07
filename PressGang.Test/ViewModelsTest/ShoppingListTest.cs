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
        public void DailyObjectivesReturnsSingleCharacter()
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            User user = context.Users.Where(u => u.UserName == "Hawkshaw").FirstOrDefault();
            Assert.IsNotNull(user);

            Character bucky = LookUp.Character(context, "Bucky");
            GoalOperations.AddYellowStarGoal(context, user, bucky);
            ShoppingList shoppingList = new(context, user);

            Opportunity o01 = shoppingList.Heroes();
            AssertOpportunity(o01, bucky, "Heroes");
            Opportunity o02 = shoppingList.Villains();
            Assert.IsNull(o02, "Opportunity from villians when none was set");

            Character danvers = LookUp.Character(context, "Captain Marvel");
            GoalOperations.AddYellowStarGoal(context, user, danvers);
            shoppingList.Update();
            Opportunity o03 = shoppingList.Heroes();
            AssertOpportunity(o03, bucky, "Heroes");

            GoalOperations.AddYellowStarGoal(context, user, danvers, top: true);
            shoppingList.Update();
            Opportunity o04 = shoppingList.Heroes();
            AssertOpportunity(o04, danvers, "Heroes");


        }

        private void AssertOpportunity(Opportunity opportunity, Character character, string campaignName)
        {
            Assert.AreEqual(campaignName, opportunity.Location.Campaign.NickName);
            Character opportunityCharacter = opportunity.Resource.Character;
            Assert.AreSame(character, opportunityCharacter, $"{opportunityCharacter.Name} == {character.Name}");
        }


    }
}
