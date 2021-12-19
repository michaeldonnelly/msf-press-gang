using System;
using System.Diagnostics;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PressGang.Core;
using PressGang.Core.Data;

namespace PressGang.Console
{
    class Program
    {
        private static AppSettings _appSettings = new AppSettings();
        private readonly PressGangContext _context;

        private static void LoadAppSettings()
        {
            ConfigurationBuilder builder = (ConfigurationBuilder)new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            ConfigurationRoot configuration = (ConfigurationRoot)builder.Build();
            ConfigurationBinder.Bind(configuration, _appSettings);
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            LoadAppSettings();


            DbContextOptionsBuilder<PressGangContext> optionsBuilder = new();
            optionsBuilder.UseSqlite(_appSettings.ConnectionString);
            DbContextOptions<PressGangContext> options = optionsBuilder.Options;
            PressGangContext context = new PressGangContext(options);
            context.Database.EnsureCreated();
            Import.ImportAll(context, _appSettings.DataDirectory);


            Debug.WriteLine(_appSettings.ConnectionString);
            string output = Core.Data.Initialize.System();

            Debug.WriteLine("\n\n");
            Debug.WriteLine(output);
            Debug.WriteLine("\n\n");

            System.Console.WriteLine("Done");
        }
    }
}
