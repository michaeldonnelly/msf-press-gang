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


    }
}
