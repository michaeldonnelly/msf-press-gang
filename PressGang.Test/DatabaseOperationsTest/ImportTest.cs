using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGang.Core;
using PressGang.Core.DatabaseContext;
using PressGang.Core.DatabaseOperations;
using PressGang.Core.Reports;
using System;
using System.Collections.Generic;

namespace PressGang.Test.DatabaseOperationsTest
{
    [TestClass]
    public class ImportTest
    {
        [TestMethod]
        public void InitialDatabaseIsEmpty()
        {
            string dbName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            SqliteConnection db = InMemoryDatabase.RawSqliteConnection(dbName);
            db.Open();
            PressGangContext context = InMemoryDatabase.GetContext(dbName);
            foreach (string tableName in Tables())
            {
                AssertRowsInTable(context, tableName, expectedRows: 0);
            }
        }

        [TestMethod]
        public void ImportAddsData()
        {
            string dbName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            SqliteConnection db = InMemoryDatabase.RawSqliteConnection(dbName);
            db.Open();
            PressGangContext context = InMemoryDatabase.GetContext(dbName);
            foreach (string tableName in Tables())
            {
                AssertRowsInTable(context, tableName, expectedRows: 0);
            }
            InMemoryDatabase.InitializeContext(context);
            foreach (string tableName in Tables())
            {
                AssertRowsInTable(context, tableName, minimumRows: 1);
            }
        }

        [TestMethod]
        public void ImportTwiceDoesntAddData()
        {
            string dbName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            SqliteConnection db = InMemoryDatabase.RawSqliteConnection(dbName);
            db.Open();

            PressGangContext context = InMemoryDatabase.InitializeContext(dbName);

            Dictionary<string, int> countsAfterFirstImport = new();
            foreach(string tableName in Tables())
            {
                countsAfterFirstImport[tableName] = StaticReports.RowsInTable(context, tableName);
            }

            InMemoryDatabase.InitializeContext(context);


            foreach (string tableName in Tables())
            {
                int expectedRows = countsAfterFirstImport[tableName];
                AssertRowsInTable(context, tableName, expectedRows: expectedRows);
            }            
        }

        private List<string> Tables()
        {
            List<string> tables = new()
            {
                "Campaigns",
                "Locations",
                "Characters",
                "Resources",
                "PrerequisiteCharacters"
            };

            return tables;
        }

        private void AssertRowsInTable(PressGangContext context, string tableName, int minimumRows = 0, int maximumRows = int.MaxValue, int? expectedRows = null)
        {
            int actualRows = StaticReports.RowsInTable(context, tableName);
            if (expectedRows.HasValue)
            {
                Assert.AreEqual((int)expectedRows, actualRows, tableName);
            }

            Assert.IsTrue(actualRows >= minimumRows, actualRows.ToString(), tableName);
            Assert.IsTrue(actualRows <= maximumRows, actualRows.ToString(), tableName);            
        }

    }
}
