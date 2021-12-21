using System;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PressGang.Core;
using PressGang.Core.Data;

namespace PressGang.Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            StartUp startUp = new StartUp();
            startUp.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            DiscordOptions discordOptions = new();
            startUp.Configuration.GetSection(DiscordOptions.Discord).Bind(discordOptions);
            System.Console.WriteLine("Hello World!");
            Listener listener = new(discordOptions);
            listener.Connect().GetAwaiter().GetResult();
        }
    }
}
