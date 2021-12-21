using System;
using Microsoft.EntityFrameworkCore;
using PressGang.Core.DynamicModels;
using PressGang.Core.StaticModels;

namespace PressGang.Core.Data
{
    public class PressGangContext : DbContext
    {
        public PressGangContext(DbContextOptions<PressGangContext> options) : base(options)
        {
        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Character> Characters { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Opportunity> Opportunties { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
