using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infra
{
    public class CampaignDbContext : DbContext
    {
        public CampaignDbContext() { }

        public CampaignDbContext(DbContextOptions<CampaignDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         //   modelBuilder.Entity<Campaign>().HasNoKey();
           // modelBuilder.Entity<Email>().HasNoKey();
        }
        public DbSet<Campaign> CampaignRecs { get; set; }

        public DbSet<Email> EmailRecs { get; set; }

    }
}
