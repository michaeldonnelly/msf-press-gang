using System;
using System.Diagnostics;
using DSharpPlus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PressGang.Core;
using PressGang.Core.DatabaseContext;

namespace PressGang.Bot
{
    class Program
    {
        static void Main(string[] args)
        {

            IServiceCollection services = new ServiceCollection();
            StartUp startUp = new StartUp();
            startUp.ConfigureServices(services);
            services.AddOptions<DiscordOptions>().Bind(startUp.Configuration.GetSection(DiscordOptions.Discord));            
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            DiscordOptions discordOptions = new();
            startUp.Configuration.GetSection(DiscordOptions.Discord).Bind(discordOptions);
            Console.WriteLine($"Starting bot {discordOptions.BotName} for environment {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}");
            DiscordClient discordClient = Listener.Initialize(discordOptions, serviceProvider);
            Listener.Connect(discordClient).GetAwaiter().GetResult();
        }
    }
}
