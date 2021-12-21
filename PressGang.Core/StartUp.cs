using System;
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
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddOptions<AppSettings>().Bind(Configuration.Get());
            //services.AddOptions<DataAccessOptions>().Bind(Configuration.GetSection(DataAccessOptions.DataAccess));
            services.AddEntityFrameworkSqlite().AddDbContext<PressGangContext>();
        }
    }
}
