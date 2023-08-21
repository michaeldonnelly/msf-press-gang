using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Zola.Database.Models;
using Zola.MsfClient.Models;

namespace Zola.Database
{
	public class MsfDbContext : DbContext
	{
		public MsfDbContext(DbSettings? options = null) 
        {            
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "msf.db");
        }

		public string DbPath { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}").EnableSensitiveDataLogging();

        public DbSet<CharacterInfo> Characters { get; set; }

        public DbSet<Trait> Traits { get; set; }

        public DbSet<Effect> Effects { get; set; }

        public DbSet<EffectIndex> EffectIndices { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
        }

        public int SafeAdd(CharacterInfo character)
        {
            if (Characters.Where(c => c.Id == character.Id).Count() > 0)
            {
                return -1;
            }

            character.Traits = TraitsFromDatabase(character.Traits);
            character.Traits.AddRange(TraitsFromDatabase(character.InvisibleTraits));
            // TODO: split out InvisibleTraits to their own thing
            //character.Traits.AddRange(TraitsFromDatabase(character.EventTraits));

            Add(character);
            return SaveChanges();
        }

        public CharacterInfo? LoadCharacter(string id)
        {
            CharacterInfo? character = Characters.Where(c => c.Id == id)
                .Include(character => character.Traits)
                .Include(character => character.GearTierCollection)
                .ThenInclude(gearTier => gearTier.Stats)
                .Include(character => character.AbilityKit.Basic.AbilityLevelCollection)
                .Include(character => character.AbilityKit.Special.AbilityLevelCollection)
                .Include(character => character.AbilityKit.Passive.AbilityLevelCollection)
                .Include(character => character.AbilityKit.Ultimate.AbilityLevelCollection)
                .FirstOrDefault();

            return character;
            //var _ = context.Characters
            //  .Include(character => character.Traits)
            //  .Include(character => character.GearTierCollection)
            //  .ThenInclude(gearTier => gearTier.Stats)
            //  .Include(character => character.AbilityKit.Basic.AbilityLevelCollection)
            //  .Include(character => character.AbilityKit.Special.AbilityLevelCollection)
            //  .Include(character => character.AbilityKit.Passive.AbilityLevelCollection)
            //  .Include(character => character.AbilityKit.Ultimate.AbilityLevelCollection)
            //  //.ThenInclude(ultimate => ultimate.AbilityLevelCollection)
            //  .ToList();


        }

        private List<Trait> TraitsFromDatabase(List<Trait>? traitsFromApi)
        {
            List<Trait> traitsFromDatabase = new();
            if (traitsFromApi is not null)
            { 
                foreach (var apiTrait in traitsFromApi)
                {
                    Trait dbTrait = Traits.Where(t => t.Id == apiTrait.Id).First();
                    traitsFromDatabase.Add(dbTrait);
                }
            }
            return traitsFromDatabase;
        }

    }
}

// dotnet ef migrations add $name