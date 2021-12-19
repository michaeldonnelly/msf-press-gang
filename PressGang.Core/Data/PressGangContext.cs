using System;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<CampaignNode> CampaignNodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
