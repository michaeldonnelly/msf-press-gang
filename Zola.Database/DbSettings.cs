using Microsoft.Extensions.Configuration;

namespace Zola.Database
{
	public class DbSettings
	{
        public DbSettings(IConfiguration config)
        {
            // TODO: actually use this; for now it's just hardcoded in the constructor for MsfDbContext

            //ConnectionString = "Data Source=myshareddb;mode=memory;cache=shared";
            //string? connectionString = config["Database:ConnectionString"];

            //if ((connectionString is null))
            //{
            //    throw new Exception("Can't create DbSettings; missing value in secrets");
            //}
            //ConnectionString = connectionString;
        }

        //public string ConnectionString { get; set; }

        //public string DataDirectory { set; get; }
    }
}

