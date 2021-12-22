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

           // AppConfig.LoadAppSettings(_appSettings);
           // PressGangContext context = AppConfig.DbContext(_appSettings);

            //string output = Core.Data.Initialize.System(context);

            //Debug.WriteLine("\n\n");
            //Debug.WriteLine(output);
            //Debug.WriteLine("\n\n");

            System.Console.WriteLine("Done");
        }
    }
}
