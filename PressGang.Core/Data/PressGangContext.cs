using System;
using Microsoft.EntityFrameworkCore;
using PressGang.Core.System.Mode;

namespace PressGang.Core.Data
{
    public class PressGangContext : DbContext
    {
        public PressGangContext(DbContextOptions<PressGangContext> options) : base (options)
        {
        }

        public DbSet<Campaign> Campaigns { get; set; }
    }
}
