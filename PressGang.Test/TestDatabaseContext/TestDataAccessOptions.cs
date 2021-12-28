using System;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGang.Core;
using PressGang.Core.DatabaseContext;

namespace PressGang.Test.TestDatabaseContext
{


    public partial class TestDataAccessOptionsBase
    {
        public DataAccessOptions Options = new();
        public readonly string EnvironmentName;
        private readonly string ExpectedDataSource;

        public TestDataAccessOptionsBase(string environmentName)  //, string expectedDataSource)
        {
            EnvironmentName = environmentName;
            //ExpectedDataSource = expectedDataSource;
        }

        [TestInitialize]
        public void StartUp()
        {
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", EnvironmentName);

            StartUp startUp = new StartUp();
            IConfiguration configuration = startUp.Configuration;
            configuration.GetSection(DataAccessOptions.DataAccess).Bind(Options);
        }

        [TestMethod]
        public void ConnectionStringStartsWithDataSource()
        {
            bool connectionStringStartsWithDataSource = Options.ConnectionString.StartsWith("Data Source");
            Assert.IsTrue(connectionStringStartsWithDataSource);
        }

        [TestMethod]
        public void ConnectionStringIsSqliteDb()
        {
            string connectionString = Options.ConnectionString;
            string dataSource = connectionString.Split('=')[1];
            if (dataSource.Contains("/"))
            {
                string[] pieces = dataSource.Split('/');
                dataSource = pieces[pieces.Length - 1];
            }
            Assert.AreEqual(ExpectedDataSource, dataSource);
        }


    }

    [TestClass]
    public class TestDataAccessOptionsDev : TestDataAccessOptionsBase
    {
        private const string _environmentName = "Development";

        public TestDataAccessOptionsDev() : base(_environmentName)
        {
            //string environmentName = ;
            //string expectedDataSource = "pressgang.Development.sqlite3";
            //return base(environmentName, expectedDataSource);
        }

        [TestMethod]
        public void EnvironmentIsRight()
        {
            string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            Assert.AreEqual("Development", environment);
        }


    }




    
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
