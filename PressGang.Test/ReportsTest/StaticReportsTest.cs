﻿using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGang.Core;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DatabaseOperations;
using PressGang.Core.Reports;
using PressGang.Core.StaticModels;
using System;
using System.Collections.Generic;

namespace PressGang.Test.ReportsTest
{
    [TestClass]
    public class StaticReportsTest
    {
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            var keepalive = InMemoryDatabase.RawSqliteConnection();
            keepalive.Open();
            InMemoryDatabase.InitializeContext();
        }

        [TestMethod]
        public void DatabaseHasCharacters()
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            int characterRows = StaticReports.RowsInTable(context, "Characters");
            Assert.IsTrue(characterRows > 100, characterRows.ToString());
        }

        private List<string> Prereqs(string characterName)
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            Character character = LookUp.Character(context, characterName);
            List<string> prereqs = StaticReports.Unlocks(context, character);
            return prereqs;
        }

        [TestMethod]
        public void IronMan()
        {
            List<string> prereqs = Prereqs("Iron Man");
            List<string> expectedList = new()
            {
                "Agent Coulson",
                "Black Widow",
                "Captain America",
                "Hawkeye",
                "Nick Fury",
                "Quake",
                "S.H.I.E.L.D. Assault",
                "S.H.I.E.L.D. Medic",
                "S.H.I.E.L.D. Operative",
                "S.H.I.E.L.D. Security",
                "S.H.I.E.L.D. Trooper"
            };

            foreach (string expected in expectedList)
            {
                AssertListContains(prereqs, expected);
            }
        }

        private void AssertListContains(List<string> actual, string expected)
        {
            bool listContainsExpectedString = actual.Contains(expected);
            Assert.IsTrue(listContainsExpectedString, $"{expected} is in list");
        }


    }
}
