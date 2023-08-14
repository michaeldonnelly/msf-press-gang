using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGang.Core;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DatabaseOperations;
using PressGang.Core.Reports;
using PressGang.Core.StaticModels;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace PressGang.Test.StaticModelsTest
{
    [TestClass]
    public class CharacterTest
    {
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            var keepalive = InMemoryDatabase.RawSqliteConnection();
            keepalive.Open();
            InMemoryDatabase.InitializeContext();
        }


        [DataTestMethod]
        [DataRow("NickFury", 3)]
        [DataRow("Phoenix", 5)]
        [DataRow("Omega Red", 5)]
        public void MinimumUnlock(string characterName, int expectedMinimumUnlock)
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            Character character = LookUp.Character(context, characterName);
            Assert.AreEqual(expectedMinimumUnlock, character.MinimumUnlockStars);
        }

    }
}
