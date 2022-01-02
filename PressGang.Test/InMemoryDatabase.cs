using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PressGang.Core.DatabaseContext;

namespace PressGang.Test
{
    public static class InMemoryDatabase
    {

        public static PressGangContext GetContext(string dbName = "pressgang-test")
        {
            DbContextOptionsBuilder<PressGangContext> optionsBuilder = new();
            string connectionString = ConnectionString(dbName);
            optionsBuilder.UseSqlite(connectionString);
            DbContextOptions<PressGangContext> options = optionsBuilder.Options;
            PressGangContext context = new PressGangContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        public static PressGangContext InitializeContext(string dbName = "pressgang-test")
        {
            PressGangContext context = GetContext(dbName);
            return InitializeContext(context);
        }

        public static PressGangContext InitializeContext(PressGangContext context)
        {
            DataAccessOptions options = new()
            {
                EnsureCreated = true,
                ImportDataDirectory = "Import",
                ImportData = true
            };
            DbInitializer.Initialize(context, options);
            return context;
        }

        public static SqliteConnection RawSqliteConnection(string dbName = "pressgang-test")
        {
            string connectionString = ConnectionString(dbName);
            return new SqliteConnection(connectionString);
        }

        private static string ConnectionString(string dbName)
        {
            return $"DataSource={dbName};mode=memory;cache=shared";
        }



    }
}
