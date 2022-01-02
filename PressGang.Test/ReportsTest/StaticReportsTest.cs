using Microsoft.Data.Sqlite;
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

        private List<string> Prereqs(string characterName, int unlockAt)
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            Character character = LookUp.Character(context, characterName);
            List<string> prereqs = StaticReports.Unlocks(context, character, unlockAt, out int _, out bool _, out int? _, out int? _, out int? _);
            return prereqs;
        }

        private void AssertListContains(List<string> actual, string expected)
        {
            bool listContainsExpectedString = actual.Contains(expected);
            Assert.IsTrue(listContainsExpectedString, $"{expected} is in list");
        }

        [TestMethod]
        public void IronMan()
        {
            List<string> prereqs = Prereqs("Iron Man", 3);
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

        [TestMethod]
        public void NickFury()
        {
            List<string> prereqs = Prereqs("fury", 3);
            List<string> expectedList = new()
            {
                "Kree Cyborg",
                "Kree Noble",
                "Kree Oracle",
                "Kree Reaper",
                "Kree Royal Guard"
            };

            foreach (string expected in expectedList)
            {
                AssertListContains(prereqs, expected);
            }
        }

        [TestMethod]
        public void JeanGrey()
        {
            List<string> prereqs = Prereqs("phoenix", 5);
            List<string> expectedList = new()
            {
                "Doctor Doom",
                "Hand Assassin",
                "Hela",
                "Loki",
                "Mordo",
                "Nobu",
                "Ronan The Accuser"
            };

            foreach (string expected in expectedList)
            {
                AssertListContains(prereqs, expected);
            }
        }

        [TestMethod]
        public void BlackagarBoltagon()
        {
            List<string> prereqs = Prereqs("blackbolt", 5);
            List<string> expectedList = new()
            {
                "Hela",
                "Loki",
                "Thor",
                "Sif",
                "Heimdall"
            };

            foreach (string expected in expectedList)
            {
                AssertListContains(prereqs, expected);
            }
        }

        [TestMethod]
        public void Shuri()
        {
            List<string> prereqs = Prereqs("SHURI", 5);
            List<string> expectedList = new()
            {
                "Doctor Octopus",
                "Electro",
                "Green Goblin",
                "Mysterio",
                "Rhino",
                "Shocker",
                "Swarm",
                "Vulture",
                "Anti-Venom",
                "Carnage",
                "Scream",
                "Spider-Man",
                "Spider-Man (Miles)",
                "Spider-Man (Symbiote)",
                "Ghost-Spider",
                "Scarlet Spider",
                "Spider-Punk"
            };

            foreach (string expected in expectedList)
            {
                AssertListContains(prereqs, expected);
            }
        }

        [TestMethod]
        public void UnlockLevelBelowMinThrowsException()
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            Character character = LookUp.Character(context, "Phoenix");
            int unlockAtStars = 4;
            Assert.ThrowsException<Exception>(() =>
                _ = StaticReports.Unlocks(context, character, unlockAtStars, out _, out _, out _, out _, out _)
                );

        }

        [DataTestMethod]
        [DataRow("fury", 3, 3)]
        public void RequiredStars(string characterName, int unlockAtStars, int expectedRequiredStars)
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            Character character = LookUp.Character(context, characterName);
            _ = StaticReports.Unlocks(context, character, unlockAtStars, out int requiredStars, out _, out _, out _, out _);
            Assert.AreEqual(expectedRequiredStars, requiredStars, $"requiredStars for {character.Name}");
        }

        [DataTestMethod]
        [DataRow("fury", 3, null)]
        [DataRow("omega red", 5, 65)]
        public void RequiredClassLevel(string characterName, int unlockAtStars, int? expectedRequiredClassLevel)
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            Character character = LookUp.Character(context, characterName);
            _ = StaticReports.Unlocks(context, character, unlockAtStars, out _, out _, out int? requiredCharacterLevel, out _, out _);
            Assert.AreEqual(expectedRequiredClassLevel, requiredCharacterLevel, $"requiredClassLevel for {character.Name}");
        }

        [DataTestMethod]
        [DataRow("fury", 3, null)]
        [DataRow("omega red", 5, 12)]
        public void RequiredGearTier(string characterName, int unlockAtStars, int? expectedRequiredGearTier)
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            Character character = LookUp.Character(context, characterName);
            _ = StaticReports.Unlocks(context, character, unlockAtStars, out _, out _, out _, out int? requiredGearTier, out _);
            Assert.AreEqual(expectedRequiredGearTier, requiredGearTier, $"requiredGearTier for {character.Name}");
        }

        [DataTestMethod]
        [DataRow("fury", 3, null)]
        [DataRow("omega red", 5, 3)]
        public void RequiredIso8ClassLevel(string characterName, int unlockAtStars, int? expectedRequiredIso8ClassLevel)
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            Character character = LookUp.Character(context, characterName);
            _ = StaticReports.Unlocks(context, character, unlockAtStars, out _, out _, out _, out _, out int? requiredIso8ClassLevel);
            Assert.AreEqual(expectedRequiredIso8ClassLevel, requiredIso8ClassLevel, $"requiredIso8ClassLevel for {character.Name}");
        }





    }
}
