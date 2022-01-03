using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DatabaseOperations;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

namespace PressGang.Test.DatabaseOperationsTest
{
    [TestClass]
    public class GoalOperationsTest
    {
        [TestInitialize]
        public void Init()
        {
            var keepalive = InMemoryDatabase.RawSqliteConnection();
            keepalive.Open();
            InMemoryDatabase.InitializeContext();
            InitExampleGoals();
        }

        private void InitExampleGoals()
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            Character storm = LookUp.Character(context, "Storm");
            Character beast = LookUp.Character(context, "Beast");
            User hawkshaw = LookUp.User(context, Constants.Hawkshaw.DiscordId, Constants.Hawkshaw.UserName);

            YellowStarGoal sg = new(hawkshaw, storm, priority: 1);
            YellowStarGoal bg = new(hawkshaw, beast, priority: 2);

            context.Add(sg);
            context.Add(bg);
            context.SaveChanges();
        }

        [TestMethod]
        public void YellowStarGoalListToDictionary()
        {
            YellowStarGoal wg = new(Constants.Hawkshaw, Constants.Logan)
            {
                Priority = 2
            };
            YellowStarGoal sg = new(Constants.Hawkshaw, Constants.Peter)
            {
                Priority = 1
            };
            List<YellowStarGoal> ysgList = new();
            ysgList.Add(wg);
            ysgList.Add(sg);

            List<IGoal> goalList = new List<IGoal>(ysgList);
            Dictionary<int, IGoal> goalDict = GoalOperations.GoalListToDictionary(goalList);

            Assert.AreSame(wg, goalDict[2]);
            Assert.AreSame(sg, goalDict[1]);
        }

        [TestMethod]
        public void AddYellowStarGoalBottom()
        {

        }




    }
}
