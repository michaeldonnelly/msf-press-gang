using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGang.Core;
using PressGang.Core.DatabaseContext;
using PressGang.Core.Reports;
using System;

namespace PressGang.Test.DatabaseOperationsTest
{
    [TestClass]
    public class ImportTest
    {

        [TestInitialize]
        public void OpenInMemoryDb()
        {
            
        }


        [TestMethod]
        public void InitialDatabaseIsEmpty()
        {
            SqliteConnection db = InMemoryDatabase.RawSqliteConnection(shared: false);
            db.Open();
            PressGangContext context = InMemoryDatabase.GetContext(shared: false);
            int characterRows = StaticReports.RowsInTable(context, "Characters");
            Assert.AreEqual(0, characterRows);
        }

    }
}
