using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PressGang.Core.Data;

namespace PressGang.Core
{
    public class StartUp
    {
        public IConfiguration Configuration { get; }

        public StartUp()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            DataAccessOptions dataAccessOptions = new();
            Configuration.GetSection(DataAccessOptions.DataAccess).Bind(dataAccessOptions);
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
            //services.AddOptions<AppSettings>().Bind(Configuration.Get());
            services.AddOptions<DataAccessOptions>().Bind(Configuration.GetSection(DataAccessOptions.DataAccess));
            services.AddEntityFrameworkSqlite().AddDbContext<PressGangContext>();
        }
    }
}
