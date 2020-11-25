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
        public DbSet<Review> Reviews { get; set; }

        public UyNaturalContext(DbContextOptions options) : base(options)
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().Property(a => a.Price).IsRequired();
            modelBuilder.Entity<Reservation>().Property(a => a.Code).IsRequired();
            modelBuilder.Entity<Reservation>().Property(a => a.CheckIn).IsRequired();
            modelBuilder.Entity<Reservation>().Property(a => a.CheckOut).IsRequired();

            modelBuilder.Entity<Lodging>().Property(a => a.Capacity).IsRequired();
            modelBuilder.Entity<Lodging>().Property(a => a.Direction).IsRequired();
            modelBuilder.Entity<Lodging>().Property(a => a.Name).IsRequired();
            modelBuilder.Entity<Lodging>().Property(a => a.Stars).IsRequired();
            modelBuilder.Entity<Lodging>().Property(a => a.Price).IsRequired();

            modelBuilder.Entity<Person>().Property(a => a.Mail).IsRequired();
            modelBuilder.Entity<Person>().Property(a => a.Name).IsRequired();
            modelBuilder.Entity<Person>().Property(a => a.Surname).IsRequired();

            modelBuilder.Entity<State>().Property(a => a.Name).IsRequired();

            modelBuilder.Entity<TouristicPoint>().Property(a => a.Name).IsRequired();

            modelBuilder.Entity<Person>()
                .HasDiscriminator<int>("PersonType")
                .HasValue<Client>(1)
                .HasValue<Administrator>(2);

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
