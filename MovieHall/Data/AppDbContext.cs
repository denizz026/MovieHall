using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MovieHall.Models;

namespace MovieHall.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor with DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UpcomingMovie> UpcomingMovies { get; set; }

        // Fluent API configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Movie entity
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(m => m.Id); // Primary key
                entity.Property(m => m.Title)
                      .IsRequired()
                      .HasMaxLength(200); // Title field with max length
            });

            // Configure UpcomingMovie entity
            modelBuilder.Entity<UpcomingMovie>(entity =>
            {
                entity.HasKey(u => u.Id); // Primary key
                entity.Property(u => u.ReleaseDate)
                      .IsRequired(); // Ensure ReleaseDate is not null
            });            

        }

        // Optional: OnConfiguring for fallback
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-C7NOD6F\\SQLEXPRESS;Database=contextDB;Trusted_Connection=True;");
            }
        }
    }
}
