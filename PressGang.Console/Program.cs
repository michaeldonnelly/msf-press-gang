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
        //private readonly PressGangContext _context;


        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            AppConfig.LoadAppSettings(_appSettings);


            //DbContextOptionsBuilder<PressGangContext> optionsBuilder = new();
            //optionsBuilder.UseSqlite(_appSettings.ConnectionString);
            //DbContextOptions<PressGangContext> options = optionsBuilder.Options;
            //PressGangContext context = new PressGangContext(options);
            //context.Database.EnsureCreated();
            //Import.ImportAll(context, _appSettings.DataDirectory);

            PressGangContext context = AppConfig.DbContext(_appSettings);


            Debug.WriteLine(_appSettings.ConnectionString);
            string output = Core.Data.Initialize.System(context);

            Debug.WriteLine("\n\n");
            Debug.WriteLine(output);
            Debug.WriteLine("\n\n");

            System.Console.WriteLine("Done");
        }
    }
}
