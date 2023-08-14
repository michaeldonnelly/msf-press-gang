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
        public void Falcon(string characterName)
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            Character falcon = LookUp.Character(context, characterName);
            Assert.IsNotNull(falcon);
            Assert.AreEqual("Falcon", falcon.Name, characterName);
        }

        [DataTestMethod]
        [DataRow("NickFury")]
        [DataRow("Nick Fury")]
        [DataRow("NF")]
        [DataRow("Fury")]
        [DataRow("Nick")]
        public void NickFury(string characterName)
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            Character nickfury = LookUp.Character(context, characterName);
            Assert.IsNotNull(nickfury, "searched for " + characterName);
            Assert.AreEqual("Nick Fury", nickfury.Name, "searched for " + characterName);
        }

    }
}
