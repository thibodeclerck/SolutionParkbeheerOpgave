using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class ParkBeheerContext : DbContext
    {
        private string connectionString;

        public ParkBeheerContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<HuisEF> Huis { get; set; }
        public DbSet<HuurcontractEF> Huurcontract { get; set; }
        public DbSet<HuurderEF> Huurder { get; set; }
        public DbSet<ParkEF> Park { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<HuisEF>()
            //    .HasOne(x => x.Park)
            //    .WithMany();
            //modelBuilder.Entity<HuisEF>()
            //    .HasMany(x => x.Huurcontracten)
            //    .WithOne();
            //modelBuilder.Entity<HuurderEF>()
            //    .HasMany(x => x.Huurcontracten)
            //    .WithOne();
            
        }
    }
}
