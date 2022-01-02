using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PressGang.Core.DatabaseContext;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

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
            Character character = ExactMatch(context, name);
            if (character == null)
            {
                character = StartsWithMatch(context, name);
            }

            if (character == null)
            {
                return null;
            }

            context.Entry(character).Collection(c => c.PrerequisiteCharacters).Load();
            context.Entry(character).Collection(c => c.CharacterAliases).Load();
            context.Entry(character).Reference(c => c.Shard).Load();
            return character;
        }

        private static Character ExactMatch(PressGangContext context, string name)
        {
            name = name.ToLower();
            List<Character> characters = context.Characters.Where(c => c.Name.ToLower() == name).ToList();
            if (characters.Count == 1)
            {
                return characters[0];
            }

            List<CharacterAlias> aliases = context.CharacterAliases.Where(a => a.Alias.ToLower() == name).Include("Character").ToList();           
            if (aliases.Count == 1)
            {
                Character character = aliases[0].Character;
                return character;
            }

            return null;
        }

        private static Character StartsWithMatch(PressGangContext context, string name)
        {
            name = name.ToLower();
            List<Character> characters = context.Characters.Where(c => c.Name.ToLower().StartsWith(name)).ToList();
            List<CharacterAlias> aliases = context.CharacterAliases.Where(a => a.Alias.ToLower().StartsWith(name)).Include("Character").ToList();
            foreach (CharacterAlias alias in aliases)
            {
                Character character = alias.Character;
                if (!characters.Contains(character))
                {
                    characters.Add(character);
                }
            }

            if (characters.Count == 1)
            {
                return characters[0];
            }

            return null;
        }

        public static PrerequisiteCharacter Prerequisite(PressGangContext context, Character character, Character dependsOn)
        {
            List<PrerequisiteCharacter> results = context.PrerequisiteCharacters
                .Where(p => (p.Character == character) && (p.DependsOn == dependsOn))
                .ToList();

            if (results.Count == 1)
            {
                return results[0];
            }

            return null;
        }

        public static PrerequisiteStats PrerequisiteStats(PressGangContext context, Character character, int yellowStars)
        {
            List<PrerequisiteStats> results = context.PrerequisiteStats
                .Where(ps => (ps.Character == character) && (ps.YellowStars == yellowStars))
                .ToList();

            return results.FirstOrDefault();
        }

        public static User User(PressGangContext context, ulong discordId, string userName)
        {
            List<User> results = context.Users.Where(u => u.DiscordId == discordId).ToList();
            User user;
            if (results.Count == 0)
            {
                user = new(discordId, userName);
                context.Users.Add(user);
                context.SaveChanges();
            }
            else
            {
                user = results[0];
            }
            return user;
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
