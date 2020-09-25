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

        public UyNaturalContext(DbContextOptions options) : base(options)
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Properties
            //modelBuilder.Entity<Author>().Property(a => a.Username).HasMaxLength(10);

            //Inheritance
            modelBuilder.Entity<Person>()
                .HasDiscriminator<int>("PersonType")
                .HasValue<Client>(1)
                .HasValue<Administrator>(2);

            /*
            modelBuilder.Entity<Administrator>().ToTable("Admin");
            modelBuilder.Entity<Client>().ToTable("Client");
            */

            //Many to many TouristicPoints-Category
            modelBuilder.Entity<TouristicPointsCategory>()
                .HasKey(x => new { x.TouristicPointId, x.CategoryId });

            modelBuilder.Entity<TouristicPointsCategory>()
                .HasOne(x => x.TouristicPoint)
                .WithMany(x => x.TouristicPointsCategory)
                .HasForeignKey(x => x.TouristicPointId);

            modelBuilder.Entity<TouristicPointsCategory>()
                .HasOne(x => x.Category)
                .WithMany(x => x.TouristicPointsCategory)
                .HasForeignKey(x => x.CategoryId);
        }

        
    }
}
