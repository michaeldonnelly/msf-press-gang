using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PressGang.Test
{
    [TestClass]
    public class UnitTest1
    {
        private const string TestEnvironmentName = "AutomatedTesting";

        [TestInitialize]
        public void StartUp()
        {
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", TestEnvironmentName);
        }


        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }


        [TestMethod]
        public void EnvironmentIsAutomatedTest()
        {
            string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            Assert.AreEqual(TestEnvironmentName, environment);
        }
    }
}
