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
            LoadAppSettings();

            DbContextOptionsBuilder<PressGangContext> optionsBuilder = new();
            optionsBuilder.UseSqlite("foo");
            DbContextOptions<PressGangContext> options = optionsBuilder.Options;
            PressGangContext context = new PressGangContext(options);
            Import.ImportCampaigns(context, _appSettings.DataDirectory);


            Debug.WriteLine(_appSettings.DataDirectory);
            string output = Core.Data.Initialize.System();

            Debug.WriteLine("\n\n");
            Debug.WriteLine(output);
            Debug.WriteLine("\n\n");

            System.Console.WriteLine("Hello World!");
        }
    }
}
