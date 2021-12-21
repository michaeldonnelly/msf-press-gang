using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;
using Microsoft.Extensions.Configuration;
using PressGang.Core;

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
            Listener.Initialize(_appSettings).GetAwaiter().GetResult();
        }
    }
}
