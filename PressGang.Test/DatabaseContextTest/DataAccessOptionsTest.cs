using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGang.Core;
using PressGang.Core.DatabaseContext;

namespace PressGang.Test.DatabaseContextTest
{
    public partial class DataAccessOptionsTestBase
    {
        public DataAccessOptions Options = new();
        public readonly string EnvironmentName;
        private readonly string ExpectedDataSource;

        public DataAccessOptionsTestBase(string environmentName, string expectedDataSource)
        {
            EnvironmentName = environmentName;
            ExpectedDataSource = expectedDataSource;
        }

        [TestInitialize]
        public void StartUp()
        {
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", EnvironmentName);

            StartUp startUp = new StartUp(initializeDataBaseConnection: false);
            IConfiguration configuration = startUp.Configuration;          
            configuration.GetSection(DataAccessOptions.DataAccess).Bind(Options);
        }

        [TestMethod]
        public void ConnectionStringStartsWithDataSource()
        {
            string connectionString = Options.ConnectionString;
            bool connectionStringStartsWithDataSource = connectionString.StartsWith("Data Source");
            Assert.IsTrue(connectionStringStartsWithDataSource, connectionString);
        }

        [TestMethod]
        public void DataSourceIsSqliteDb()
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
    public class DataAccessOptionsTestDev : DataAccessOptionsTestBase
    {
        private const string _environmentName = "Development";
        private const string _expectedDataSource = "pressgang-dev.sqlite3";

        public DataAccessOptionsTestDev() : base(_environmentName, _expectedDataSource)
        {  }

        [TestMethod]
        public void EnvironmentIsDevelopment()
        {
            string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            Assert.AreEqual("Development", environment);
        }
    }

    [TestClass]           
    public class DataAccessOptionsTestProd : DataAccessOptionsTestBase
    {
        private const string _environmentName = null;
        private const string _expectedDataSource = "pressgang.sqlite3";

        public DataAccessOptionsTestProd() : base(_environmentName, _expectedDataSource)
        { }

        [TestMethod]
        public void EnvironmentIsNull()
        {
            string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            Assert.IsNull(environment);
        }

    }

    [TestClass]
    public class DataAccessOptionsTestTest : DataAccessOptionsTestBase
    {
        private const string _environmentName = "AutomatedTesting";
        private const string _expectedDataSource = ":memory:";

        public DataAccessOptionsTestTest() : base(_environmentName, _expectedDataSource)
        { }

        [TestMethod]
        public void EnvironmentIsAutomatedTesting()
        {
            string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            Assert.AreEqual("AutomatedTesting", environment);
        }
    }
}
