using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection;
using PressGang.Core;
using PressGang.Core.Data;

namespace PressGang.Bot
{
    class Program
    {
        private static AppSettings _appSettings = new AppSettings();


        static void Main(string[] args)
        {
            IServiceCollection services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            StartUp startUp = new StartUp();
            startUp.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();





            AppConfig.LoadAppSettings(_appSettings);

            //ServiceCollection serviceCollection = new ServiceCollection()
            //    .AddSingleton<AppSettings>()
            //    .BuildServiceProvider();

            Debug.WriteLine(AppConfig.DiscordToken(_appSettings));
            System.Console.WriteLine("Hello World!");
            PressGangContext context = AppConfig.DbContext(_appSettings);
            Listener listener = new(_appSettings, context);
            listener.Connect().GetAwaiter().GetResult();
        }
    }
}
