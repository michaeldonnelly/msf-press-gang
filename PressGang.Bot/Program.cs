using System;
using System.Diagnostics;
using DSharpPlus;
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
            Console.WriteLine("Hello World!");
            DiscordClient discordClient = Listener.Initialize(discordOptions, serviceProvider);
            Listener.Connect(discordClient).GetAwaiter().GetResult();
        }
    }
}
