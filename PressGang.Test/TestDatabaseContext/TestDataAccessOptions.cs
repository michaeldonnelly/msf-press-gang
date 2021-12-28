using System;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGang.Core;
using PressGang.Core.DatabaseContext;

namespace PressGang.Test.TestDatabaseContext
{
    [TestClass]
    public class TestDataAccessOptions
    {
        private DataAccessOptions _dataAccessOptions;

        [TestInitialize]
        public void StartUp()
        {
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT",null);

            StartUp startUp = new StartUp();
            IConfiguration configuration = startUp.Configuration;
            configuration.GetSection(DataAccessOptions.DataAccess).Bind(_dataAccessOptions);

        }

        [TestMethod]
        public void EnvironmentIsNullForProd()
        {
            string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            Assert.IsNull(environment);
        }

        [TestMethod]
        public void ConnectionStringStartsWithDataSource()
        {
            bool connectionStringStartsWithDataSource = _dataAccessOptions.ConnectionString.StartsWith("Data Source");
            Assert.IsTrue(connectionStringStartsWithDataSource);
        }

        [TestMethod]
        public void ConnectionStringIsSqliteDb()
        {
            bool connectionStringIsSqliteDb = _dataAccessOptions.ConnectionString.EndsWith("pressgang.sqlite3");
            Assert.IsTrue(connectionStringIsSqliteDb);
        }



    }
}
