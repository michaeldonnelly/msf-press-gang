using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PressGang.Core.UserModels;
using PressGang.Core.StaticModels;

namespace PressGang.Core.DatabaseContext
{
    public class PressGangContext : DbContext
    {
        public PressGangContext(DbContextOptions<PressGangContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration Configuration = StartUp.GetConfiguration();
                DataAccessOptions dataAccessOptions = StartUp.GetDataAccessOptions(Configuration);
                optionsBuilder.UseSqlite(dataAccessOptions.ConnectionString);
            }
        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterAlias> CharacterAliases { get; set; }
        public DbSet<PrerequisiteCharacter> PrerequisiteCharacters { get; set; }
        public DbSet<PrerequisiteStats> PrerequisiteStats { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Opportunity> Opportunties { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<YellowStarGoal> YellowStarGoals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterAlias>()
                .HasOne(a => a.Character)
                .WithMany(c => c.CharacterAliases);

            modelBuilder.Entity<PrerequisiteCharacter>()
                .HasOne(pc => pc.Character)
                .WithMany(c => c.PrerequisiteCharacters);

            modelBuilder.Entity<PrerequisiteCharacter>()
                .HasOne(pc => pc.DependsOn);

            modelBuilder.Entity<PrerequisiteStats>()
                .HasOne(ps => ps.Character)
                .WithMany(c => c.PrerequisiteStats);

            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Character)
                .WithOne(c => c.Shard);

            modelBuilder.Entity<Opportunity>()
                .HasOne(o => o.Resource)
                .WithMany(r => r.Opportunities);

            modelBuilder.Entity<Opportunity>()
                .HasOne(o => o.Location);

            modelBuilder.Entity<YellowStarGoal>()
                .HasOne(g => g.User)
                .WithMany(u => u.YellowStarGoals);

            modelBuilder.Entity<YellowStarGoal>()
                .HasOne(g => g.Character);
        }
    }
}
