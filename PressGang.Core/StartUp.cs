using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PressGang.Core
{
    public class StartUp
    {
        public IConfiguration Configuration {get;}

        public StartUp()
        {
            //Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

        }
    }
}
