using HouseOfJordan.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseOfJordan.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Sneaker> Sneakers => Set<Sneaker>();
        public DbSet<WishlistItem> WishlistItems => Set<WishlistItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Username unic
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // Un user nu poate avea același sneaker de 2 ori în wishlist
            modelBuilder.Entity<WishlistItem>()
                .HasIndex(w => new { w.UserId, w.SneakerId })
                .IsUnique();

            // Brand name unic
            modelBuilder.Entity<Brand>()
                .HasIndex(b => b.Name)
                .IsUnique();
        }
    }
}
