using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PressGang.Core.DatabaseContext;

namespace PressGang.Core
{
    public class StartUp
    {
        public IConfiguration Configuration { get; }

        public StartUp()
        {
            Configuration = GetConfiguration();
            DataAccessOptions dataAccessOptions = GetDataAccessOptions(Configuration);
            PressGangContext context = DbContext(dataAccessOptions);
            DbInitializer.Initialize(context, dataAccessOptions);
        }

        private PressGangContext DbContext(DataAccessOptions dataAccessOptions)
        {
            DbContextOptionsBuilder<PressGangContext> optionsBuilder = new();
            optionsBuilder.UseSqlite(dataAccessOptions.ConnectionString);

            DbContextOptions<PressGangContext> options = optionsBuilder.Options;
            PressGangContext context = new PressGangContext(options);
            return context;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions<DataAccessOptions>().Bind(Configuration.GetSection(DataAccessOptions.DataAccess));
            services.AddEntityFrameworkSqlite().AddDbContext<PressGangContext>();
        }

        public static IConfiguration GetConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");

            string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            if (!String.IsNullOrEmpty(environment))
            {
                string environmentSpecificConfig = $"appsettings.{environment}.json";
                builder.AddJsonFile(environmentSpecificConfig, optional: true);
            }

            return builder.Build();
        }

        public static DataAccessOptions GetDataAccessOptions(IConfiguration configuration)
        {
            DataAccessOptions dataAccessOptions = new();
            configuration.GetSection(DataAccessOptions.DataAccess).Bind(dataAccessOptions);
            return dataAccessOptions;
        }
    }
}
