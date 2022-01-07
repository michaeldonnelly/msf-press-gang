using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DatabaseOperations;
using PressGang.Core.Reports;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

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
            Assert.IsTrue(true);
        }


    }
}
