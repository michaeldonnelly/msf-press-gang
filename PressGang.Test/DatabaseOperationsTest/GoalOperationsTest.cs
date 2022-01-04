using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DatabaseOperations;
using PressGang.Core.Reports;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

namespace PressGang.Test.DatabaseOperationsTest
{
    [TestClass]
    public class GoalOperationsTest
    {
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            var keepalive = InMemoryDatabase.RawSqliteConnection();
            keepalive.Open();
            InMemoryDatabase.InitializeContext();
        }

        private static void InitExampleGoals(PressGangContext context, User user)
        {
            YellowStarGoal sg = new(user, Storm(context), priority: 1);
            YellowStarGoal bg = new(user, Beast(context), priority: 2);

            context.Add(sg);
            context.Add(bg);
            context.SaveChanges();
        }

        private static Character Storm(PressGangContext context)
        {
            return LookUp.Character(context, "Storm");
        }

        private static Character Beast(PressGangContext context)
        {
            return LookUp.Character(context, "Beast");
        }

        private static Character Bishop(PressGangContext context)
        {
            return LookUp.Character(context, "Bishop");
        }

        private static User Hawkshaw(PressGangContext context)
        {
            return LookUp.User(context, Constants.Hawkshaw.DiscordId, Constants.Hawkshaw.UserName);
        }

        private static User SampleUser(PressGangContext context, string testName)
        {
            User user = new()
            {
                UserName = $"user for {testName}",
                DiscordId = StringToUlong(testName)
            };
            context.Add(user);
            context.SaveChanges();
            return user;
        }

        private static ulong StringToUlong(string stringToHash)
        {
            ulong hash = 0;
            for (int cursor = 0; cursor < stringToHash.Length; cursor++)
            {
                char c = stringToHash[cursor];
                hash += (ulong)c;
            }
            return hash;
        }

        [TestMethod]
        public void YellowStarGoalListToDictionary()
        {
            YellowStarGoal wg = new(Constants.Hawkshaw, Constants.Logan, priority: 2);
            YellowStarGoal sg = new(Constants.Hawkshaw, Constants.Peter, priority: 1);
            List<YellowStarGoal> ysgList = new();
            ysgList.Add(wg);
            ysgList.Add(sg);

            List<IGoal> goalList = new List<IGoal>(ysgList);
            Dictionary<int, IGoal> goalDict = GoalReports.GoalListToDictionary(goalList);

            Assert.AreSame(wg, goalDict[2]);
            Assert.AreSame(sg, goalDict[1]);
        }

        [TestMethod]
        public void DbHasSampleGoals()
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            User user = SampleUser(context, System.Reflection.MethodBase.GetCurrentMethod().Name);
            InitExampleGoals(context, user);
            List<YellowStarGoal> ysgList = user.YellowStarGoals;
            List<IGoal> goalList = new(ysgList);
            Dictionary<int, IGoal> goalDict = GoalReports.GoalListToDictionary(goalList);
            AssertGoalIsForCharacter(Storm(context), goalDict[1]);
            AssertGoalIsForCharacter(Beast(context), goalDict[2]);
        }

        private void AssertGoalIsForCharacter(Character expected, IGoal actual)
        {
            YellowStarGoal yellowStarGoal = (YellowStarGoal)actual;
            Assert.AreSame(expected, yellowStarGoal.Character);
        }

        [TestMethod]
        public void AddYellowStarGoalToBottom()
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            User user = SampleUser(context, System.Reflection.MethodBase.GetCurrentMethod().Name);
            InitExampleGoals(context, user);
            GoalOperations.AddYellowStarGoal(context, user, Bishop(context));

            List<YellowStarGoal> ysgList = user.YellowStarGoals;
            List<IGoal> goalList = new(ysgList);
            Dictionary<int, IGoal> goalDict = GoalReports.GoalListToDictionary(goalList);
            AssertGoalIsForCharacter(Storm(context), goalDict[1]);
            AssertGoalIsForCharacter(Beast(context), goalDict[2]);
            AssertGoalIsForCharacter(Bishop(context), goalDict[3]);
        }

        [TestMethod]
        public void AddYellowStarGoalToTop()
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            User user = SampleUser(context, System.Reflection.MethodBase.GetCurrentMethod().Name);
            InitExampleGoals(context, user);
            GoalOperations.AddYellowStarGoal(context, user, Bishop(context), top: true);

            List<YellowStarGoal> ysgList = user.YellowStarGoals;
            List<IGoal> goalList = new(ysgList);
            Dictionary<int, IGoal> goalDict = GoalReports.GoalListToDictionary(goalList);
            AssertGoalIsForCharacter(Bishop(context), goalDict[1]);
            AssertGoalIsForCharacter(Storm(context), goalDict[2]);
            AssertGoalIsForCharacter(Beast(context), goalDict[3]);
        }

        [TestMethod]
        public void AddYellowStarGoalToMiddle()
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            User user = SampleUser(context, System.Reflection.MethodBase.GetCurrentMethod().Name);
            InitExampleGoals(context, user);
            GoalOperations.AddYellowStarGoal(context, user, Bishop(context), priority: 2);

            List<YellowStarGoal> ysgList = user.YellowStarGoals;
            List<IGoal> goalList = new(ysgList);
            Dictionary<int, IGoal> goalDict = GoalReports.GoalListToDictionary(goalList);
            AssertGoalIsForCharacter(Storm(context), goalDict[1]);
            AssertGoalIsForCharacter(Bishop(context), goalDict[2]);
            AssertGoalIsForCharacter(Beast(context), goalDict[3]);
        }
    }
}
