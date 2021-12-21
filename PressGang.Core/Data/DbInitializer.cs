using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PressGang.Core.StaticModels;
using PressGang.Core.DynamicModels;

namespace PressGang.Core.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PressGangContext context, DataAccessOptions options)
        {
            //TODO: Migrations
            if (options.EnsureCreated)
            {
                context.Database.EnsureCreated();
            }
            if (options.ImportData)
            {
                Import.ImportAll(context, options.ImportDataDirectory);
            }
        }
    }
}
