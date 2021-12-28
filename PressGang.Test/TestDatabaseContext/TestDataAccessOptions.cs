using System;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGang.Core;
using PressGang.Core.DatabaseContext;

namespace PressGang.Test.TestDatabaseContext
{


    public partial class TestDataAccessOptionsBase
    {
        private DataAccessOptions Options = new();
        public readonly string EnvironmentName;

        public TestDataAccessOptionsBase(string environmentName)
        {
            EnvironmentName = environmentName;
        }

        [TestInitialize]
        public void StartUp()
        {
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", EnvironmentName);
        }
    }

    [TestClass]
    public class TestDataAccessOptionsDev : TestDataAccessOptionsBase
    {
        public TestDataAccessOptionsDev() : base("Development")
        { }

        [TestMethod]
        public void EnvironmentIsRight()
        {
            string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            Assert.AreEqual("Development", environment);
        }


    }




    [TestClass]
    public class TestDataAccessOptions
    {
        private DataAccessOptions _dataAccessOptions = new();

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
