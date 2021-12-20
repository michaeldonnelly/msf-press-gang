using System;
using Microsoft.EntityFrameworkCore;
using PressGang.Core.System;
using PressGang.Core.System.Location;
using PressGang.Core.System.Mode;

namespace PressGang.Core.Data
{
    public class PressGangContext : DbContext
    {
        public PressGangContext(DbContextOptions<PressGangContext> options) : base(options)
        {
        }

        public DbSet<Campaign> Campaigns { get; set; }

        //public DbSet<CampaignNode> CampaignNodes { get; set; }
        public DbSet<Character> Characters { get; set; }

        public DbSet<ResourceLocation> Locations { get; set; }
        //public DbSet<CharacterShard> CharacterShards { get; set; }
        //public DbSet<Opportunity> Opportunties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
