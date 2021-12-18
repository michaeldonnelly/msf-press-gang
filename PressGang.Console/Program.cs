using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace PressGang.Console
{
    class Program
    {
        private static AppSettings appSettings = new AppSettings();

        private static void LoadAppSettings()
        {
            ConfigurationBuilder builder = (ConfigurationBuilder)new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            ConfigurationRoot configuration = (ConfigurationRoot)builder.Build();
            ConfigurationBinder.Bind(configuration, appSettings);
        }

        static void Main(string[] args)
        {
            LoadAppSettings();
            Debug.WriteLine(appSettings.DataDirectory);
            string output = Core.Data.Initialize.System();

            Debug.WriteLine("\n\n");
            Debug.WriteLine(output);
            Debug.WriteLine("\n\n");

            System.Console.WriteLine("Hello World!");
        }
    }
}
