using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;
using Microsoft.Extensions.Configuration;
using PressGang.Core;
using PressGang.Core.Data;

namespace PressGang.Bot
{
    class Program
    {
        private static AppSettings _appSettings = new AppSettings();


        static void Main(string[] args)
        {
            AppConfig.LoadAppSettings(_appSettings);

            Debug.WriteLine(AppConfig.DiscordToken(_appSettings));
            System.Console.WriteLine("Hello World!");
            PressGangContext context = AppConfig.DbContext(_appSettings);
            Listener listener = new(_appSettings, context);
            listener.Connect().GetAwaiter().GetResult();
        }
    }
}
