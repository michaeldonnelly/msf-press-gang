using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PressGang.Core.DatabaseContext;

namespace PressGang.Test
{
    public static class InMemoryDatabase
    {
        public static string ConnectionString = "DataSource=myshareddb;mode=memory;cache=shared";

        public static string SoloConnectionString = "DataSource=myshareddb;mode=memory";

        public static PressGangContext GetContext(bool shared = true)
        {
            DbContextOptionsBuilder<PressGangContext> optionsBuilder = new();
            string connectionString = GetConnectionString(shared);
            optionsBuilder.UseSqlite(connectionString);
            DbContextOptions<PressGangContext> options = optionsBuilder.Options;
            PressGangContext context = new PressGangContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        public static PressGangContext InitializeContext()
        {
            PressGangContext context = GetContext();
            DataAccessOptions options = new()
            {
                EnsureCreated = true,
                ImportDataDirectory = "/Users/donnelly/Repos/msf-press-gang/Data",
                ImportData = true
            };
            DbInitializer.Initialize(context, options);
            return context;
        }

        public static SqliteConnection RawSqliteConnection(bool shared = true)
        {
            string connectionString = GetConnectionString(shared);
            return new SqliteConnection(connectionString);
        }

        private static string GetConnectionString(bool shared)
        {
            if (shared)
            {
                return ConnectionString;
            }
            else
            {
                return SoloConnectionString;
            }
        }



    }
}
