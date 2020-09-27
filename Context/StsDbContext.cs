using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendSignToSem.Models;

namespace BackendSignToSem.Context
{
    public class StsDbContext : DbContext
    {


        public DbSet<BackendSignToSem.Models.Seminar> Seminars { get; set; }

        public DbSet<BackendSignToSem.Models.Booking> Bookings { get; set; }


        public StsDbContext(DbContextOptions<StsDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seminar>().HasMany(s => s.Bookings)
                  .WithOne(b => b.Seminar).IsRequired();


            //modelBuilder.Entity<Booking>().HasRequired<Seminar>(b => b.Seminar)
            //    .WithMany(s => s.Bookings).HasForeignKey<int>(b => b.Seminar);

            
        }
    }
}
