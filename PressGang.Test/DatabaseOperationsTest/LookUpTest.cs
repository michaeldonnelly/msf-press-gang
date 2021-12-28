using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGang.Core;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DatabaseOperations;
using PressGang.Core.StaticModels;

namespace PressGang.Test.DatabaseOperationsTest
{
    //[TestClass]
    //public class LookUpTest
    //{
    //    private static TestContext ClassTestContext { get; set; } // global class test context

    //    [ClassInitialize]
    //    public static void Init(TestContext testContext)
    //    {
    //        ClassTestContext = testContext;

    //        Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "AutomatedTesting");
    //        StartUp startUp = new StartUp();
    //        PressGangContext pressGangContext = startUp.PressGangContext;
    //        ClassTestContext.Properties["PressGangContext"] = pressGangContext;
    //    }

    //    [TestMethod]
    //    public void foo()
    //    {
    //        Assert.IsTrue(true);
    //    }

    //    [TestMethod]
    //    public void CharacterExactMatch()
    //    {
    //        PressGangContext context = (PressGangContext)ClassTestContext.Properties["PressGangContext"];
    //        Character falcon = LookUp.Character(context, "Falcon");
    //        Assert.IsNotNull(falcon);
    //        Assert.AreEqual("Falcon", falcon.Name);
    //    }
    //}
}
