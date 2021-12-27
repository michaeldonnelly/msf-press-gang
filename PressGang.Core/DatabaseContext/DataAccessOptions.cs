using System;
namespace PressGang.Core.DatabaseContext
{
    public class DataAccessOptions
    {
        public const string DataAccess = nameof(DataAccess);

        public string ConnectionString { get; set; }

        public string ImportDataDirectory { get; set; }

        public bool EnsureCreated { get; set; }

        public bool RunMigrations { get; set; }

        public bool ImportData { get; set; }

        public bool DebugImport { get; set; }
    }
}
