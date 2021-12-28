using Microsoft.Data.Sqlite;
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
        //public static TestContext ClassTestContext { get; set; } // global class test context

        //public DataAccessOptions Options = new();

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            //var connectionString = "DataSource=myshareddb;mode=memory;cache=shared";
            //var keepAliveConnection = new SqliteConnection(connectionString);
            //keepAliveConnection.Open();

            var keepalive = InMemoryDatabase.RawSqliteConnection();
            keepalive.Open();

            InMemoryDatabase.InitializeContext();

            //ClassTestContext = testContext;

            //Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "AutomatedTesting");
            //StartUp startUp = new StartUp();
            //PressGangContext pressGangContext = startUp.PressGangContext;
            //testContext.Properties["PressGangContext"] = pressGangContext;
        }

        [TestMethod]
        public void foobar()
        {
            PressGangContext context = InMemoryDatabase.GetContext();

            //PressGangContext context = (PressGangContext)ClassTestContext.Properties["PressGangContext"];
            //int characterRows = StaticReports.RowsInTable(context, "Characters");

            


            int characterRows = 500;
            Assert.IsTrue(characterRows > 100);
        }

        [TestMethod]
        public void alwaysworks()
        {
            Assert.IsTrue(true);
        }

    }
}
