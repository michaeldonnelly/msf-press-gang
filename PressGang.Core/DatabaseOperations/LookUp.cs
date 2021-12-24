using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PressGang.Core.DatabaseContext;
using PressGang.Core.StaticModels;

namespace PressGang.Core.DatabaseOperations
{
    public static class LookUp
    {
        public static Resource Shard(PressGangContext context, Character character)
        {
            try
            {
                Resource shard = context.Resources.First(r =>
                        (r.ResourceType == ResourceType.CharacterShard)
                        && (r.Character == character)
                    );
                return shard;
            }
            catch(InvalidOperationException)
            {
                return null;
            }
        }

        public static Character Character(PressGangContext context, string name)
        {
            List<Character> results = context.Characters.Where(c => c.Name.ToLower().StartsWith(name.ToLower())).ToList();
            if (results.Count == 1)
            {
                return results[0];
            }

            return null;
        }

        public static Prerequisite Prerequisite(PressGangContext context, Character character, Character dependsOn)
        {
            List<Prerequisite> results = context.Prerequisites
                .Where(p => (p.Character == character) && (p.DependsOn == dependsOn))
                .ToList();

            if (results.Count == 1)
            {
                return results[0];
            }

            return null;
        }

        public static string FindTableByName(DbContext dbContext, string subject)
        {
            IModel model = dbContext.Model;
            string tableName = FindTableInModel(model, subject: subject);
            if (tableName != null)
            {
                return tableName;
            }

            IEntityType entityType = FindEntityTypeInModel(model, subject);
            if (entityType == null)
            {
                return null;
            }

            tableName = FindTableInModel(model, entityType: entityType);
            return tableName;
        }

        private static string FindTableInModel(IModel model, string subject = null, IEntityType entityType = null)
        {
            IRelationalModel relationalModel = model.GetRelationalModel();

            string tableName = null;
            foreach (ITable table in relationalModel.Tables)
            {
                if (
                    ((subject != null) && (table.Name.ToLower().Contains(subject)))
                   ||
                    ((entityType != null) && (EntityTypeForTable(table) == entityType))
                   )
                {
                    if (tableName != null)
                    {
                        // We already found a match
                        return null;
                    }

                    tableName = table.Name;
                }
            }

            return tableName;
        }

        private static IEntityType EntityTypeForTable(ITable table)
        {
            IEnumerable<ITableMapping> entityTypeMapping = table.EntityTypeMappings;
            ITableMapping tableMapping = entityTypeMapping.First<ITableMapping>();
            return tableMapping.EntityType;
        }

        private static IEntityType FindEntityTypeInModel(IModel model, string subject)
        {
            IEnumerable<IEntityType> entityTypes = model.GetEntityTypes();
            IEntityType result = null;
            foreach (IEntityType entityType in entityTypes)
            {
                string entityName = entityType.DisplayName().ToLower();
                if (entityName.Contains(subject))
                {
                    if (result != null)
                    {
                        // The subject already matched on an EntityType
                        return null;
                    }

                    result = entityType;
                }
            }
            return result;
        }


 
    }
}
