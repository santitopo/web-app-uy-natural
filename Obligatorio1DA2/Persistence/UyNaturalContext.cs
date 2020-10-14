using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class UyNaturalContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<TouristicPoint> TouristicPoints { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }

        public UyNaturalContext(DbContextOptions options) : base(options)
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Inheritance
            modelBuilder.Entity<Person>()
                .HasDiscriminator<int>("PersonType")
                .HasValue<Client>(1)
                .HasValue<Administrator>(2);

            //Many to many TouristicPoints-Category
            modelBuilder.Entity<TouristicPointsCategory>()
                .HasKey(x => new { x.TouristicPointId, x.CategoryId });

            modelBuilder.Entity<TouristicPointsCategory>()
                .HasOne(x => x.TouristicPoint)
                .WithMany(x => x.Categories)
                .HasForeignKey(x => x.TouristicPointId);

            modelBuilder.Entity<TouristicPointsCategory>()
                .HasOne(x => x.Category)
                .WithMany(x => x.TouristicPoints)
                .HasForeignKey(x => x.CategoryId);
        }

    }
}
