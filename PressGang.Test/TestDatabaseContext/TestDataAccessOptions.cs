using System;
using System.IO;
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

        public TestDataAccessOptionsBase(string environmentName, string expectedDataSource)
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
            bool connectionStringStartsWithDataSource = Options.ConnectionString.StartsWith("Data Source");
            Assert.IsTrue(connectionStringStartsWithDataSource);
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
    public class TestDataAccessOptionsDev : TestDataAccessOptionsBase
    {
        private const string _environmentName = "Development";
        private const string _expectedDataSource = "pressgang-dev.sqlite3";


        public TestDataAccessOptionsDev() : base(_environmentName, _expectedDataSource)
        {  }

        [TestMethod]
        public void EnvironmentIsDevelopment()
        {
            string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            Assert.AreEqual("Development", environment);
        }

        [TestMethod]
        public void foo()
        {

            string appsettings = File.ReadAllText("appsettings.json");
            Assert.IsNotNull(appsettings);
            string appsettingsdev = File.ReadAllText("appsettings.Development.json");
            Assert.IsNotNull(appsettingsdev);
            string appsettingstest = File.ReadAllText("appsettings.AutomatedTesting.json");
            Assert.IsNotNull(appsettingstest);

        }

    }

    [TestClass]           
    public class TestDataAccessOptionsProd : TestDataAccessOptionsBase
    {
        private const string _environmentName = null;
        private const string _expectedDataSource = "pressgang.sqlite3";

        public TestDataAccessOptionsProd() : base(_environmentName, _expectedDataSource)
        { }

        [TestMethod]
        public void EnvironmentIsNull()
        {
            string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            Assert.IsNull(environment);
        }

    }

    [TestClass]
    public class TestDataAccessOptionsTest : TestDataAccessOptionsBase
    {
        private const string _environmentName = "AutomatedTesting";
        private const string _expectedDataSource = ":memory:";

        public TestDataAccessOptionsTest() : base(_environmentName, _expectedDataSource)
        { }

        [TestMethod]
        public void EnvironmentIsAutomatedTesting()
        {
            string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            Assert.AreEqual("AutomatedTesting", environment);
        }

    }
}
