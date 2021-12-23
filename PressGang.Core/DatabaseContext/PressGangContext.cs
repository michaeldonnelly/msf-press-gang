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

        public DbSet<Location> Locations { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Opportunity> Opportunties { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Goal> Goals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Character);

            modelBuilder.Entity<Opportunity>()
                .HasOne(o => o.Resource);

            modelBuilder.Entity<Opportunity>()
                .HasOne(o => o.Location);

            modelBuilder.Entity<Goal>()
                .HasOne(g => g.User)
                .WithMany(u => u.Goals);

            modelBuilder.Entity<Goal>()
                .HasOne(g => g.Character);
        }
    }
}
