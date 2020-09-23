using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class UyNaturalContext : DbContext
    {
        public DbSet<Administrator> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<TouristicPoint> TPoints { get; set; }

        public UyNaturalContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            //optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
