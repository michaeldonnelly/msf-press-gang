using System;
namespace PressGang.Core.Data
{
    public class DataAccessOptions
    {
        public const string DataAccess = nameof(DataAccess);
        public string ConnectionString { get; set; }
    }
}
