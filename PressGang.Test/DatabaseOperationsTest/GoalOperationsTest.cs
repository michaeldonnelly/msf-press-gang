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
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            var keepalive = InMemoryDatabase.RawSqliteConnection();
            keepalive.Open();
            InMemoryDatabase.InitializeContext();
            //InitExampleGoals();
        }

        private static void InitExampleGoals(PressGangContext context)
        {
            YellowStarGoal sg = new(Hawkshaw(context), Storm(context), priority: 1);
            YellowStarGoal bg = new(Hawkshaw(context), Beast(context), priority: 2);

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

        private static User Hawkshaw(PressGangContext context)
        {
            return LookUp.User(context, Constants.Hawkshaw.DiscordId, Constants.Hawkshaw.UserName);
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
        public void DbHasSampleGoals()
        {
            PressGangContext context = InMemoryDatabase.GetContext();
            InitExampleGoals(context);
            List<YellowStarGoal> ysgList = Hawkshaw(context).YellowStarGoals;
            List<IGoal> goalList = new(ysgList);
            Dictionary<int, IGoal> goalDict = GoalOperations.GoalListToDictionary(goalList);
            AssertGoalIsForCharacter(Storm(context), goalDict[1]);
            AssertGoalIsForCharacter(Beast(context), goalDict[2]);
        }


        private void AssertGoalIsForCharacter(Character expected, IGoal actual)
        {
            YellowStarGoal yellowStarGoal = (YellowStarGoal)actual;
            Assert.AreSame(expected, yellowStarGoal.Character);
        }



        //    [TestMethod]
        //public void AddYellowStarGoalBottom()
        //{
        //    PressGangContext context = InMemoryDatabase.GetContext();
        //    Character bishop = LookUp.Character(context, "Bishop");
        //    GoalOperations.AddYellowStarGoal(context, Constants.Hawkshaw, bishop);


        //}




    }
}
