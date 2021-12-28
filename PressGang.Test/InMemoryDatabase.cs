using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PressGang.Core.DatabaseContext;

namespace PressGang.Test
{
    public static class InMemoryDatabase
    {
        public static string ConnectionString = "DataSource=myshareddb;mode=memory;cache=shared";

        public static PressGangContext GetContext()
        {
            DbContextOptionsBuilder<PressGangContext> optionsBuilder = new();
            optionsBuilder.UseSqlite(ConnectionString);
            DbContextOptions<PressGangContext> options = optionsBuilder.Options;
            PressGangContext context = new PressGangContext(options);
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

        public static SqliteConnection RawSqliteConnection()
        {
            return new SqliteConnection(ConnectionString);
        }
        


    }
}
