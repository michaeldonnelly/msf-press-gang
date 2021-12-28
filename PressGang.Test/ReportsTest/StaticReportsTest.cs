using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGang.Core;
using PressGang.Core.DatabaseContext;
using PressGang.Core.Reports;
using System;

namespace PressGang.Test.ReportsTest
{
    [TestClass]
    public class StaticReportsTest
    {
        private static TestContext ClassTestContext { get; set; } // global class test context

        public DataAccessOptions Options = new();

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            ClassTestContext = testContext;

            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "AutomatedTesting");
            StartUp startUp = new StartUp();
            PressGangContext pressGangContext = startUp.PressGangContext;
            ClassTestContext.Properties["PressGangContext"] = pressGangContext;
        }

        [TestMethod]
        public void foo()
        {
            PressGangContext context = (PressGangContext)ClassTestContext.Properties["PressGangContext"];
            int characterRows = StaticReports.RowsInTable(context, "Characters");


            Assert.IsTrue(characterRows > 100);
        }


    }
}
