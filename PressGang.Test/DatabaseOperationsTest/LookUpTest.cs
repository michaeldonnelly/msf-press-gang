using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGang.Core;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DatabaseOperations;
using PressGang.Core.Reports;
using PressGang.Core.StaticModels;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace PressGang.Test.DatabaseOperationsTest
{
    [TestClass]
    public class LookUpTest
    {
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            var keepalive = InMemoryDatabase.RawSqliteConnection();
            keepalive.Open();
            InMemoryDatabase.InitializeContext();
        }

        [DataTestMethod]
        [DataRow("Falcon")]
        [DataRow("falcon")]
        [DataRow("FALCON")]
        [DataRow("fal")]
        [DataRow("falc")]
        public void FalconByName(string characterName)
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            Character falcon = LookUp.Character(context, characterName);
            Assert.IsNotNull(falcon);
            Assert.AreEqual("Falcon", falcon.Name, characterName);
        }

    }
}
