using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PressGang.Core.Data;

namespace PressGang.Core
{
    public static class AppConfig
    {
        public static void LoadAppSettings(AppSettings appSettings)
        {
            ConfigurationBuilder builder = (ConfigurationBuilder)new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            ConfigurationRoot configuration = (ConfigurationRoot)builder.Build();
            ConfigurationBinder.Bind(configuration, appSettings);
        }

        public static PressGangContext DbContext(AppSettings appSettings)
        {
            DbContextOptionsBuilder<PressGangContext> optionsBuilder = new();
            optionsBuilder.UseSqlite(appSettings.ConnectionString);
            DbContextOptions<PressGangContext> options = optionsBuilder.Options;
            PressGangContext context = new PressGangContext(options);
            context.Database.EnsureCreated();
            Import.ImportAll(context, appSettings.DataDirectory);
            return context;
        }

        public static string DiscordToken(AppSettings appSettings)
        {
            string token = File.ReadAllText(appSettings.DataDirectory + "/discord-token.txt");
            return token;
        }
    }
}
