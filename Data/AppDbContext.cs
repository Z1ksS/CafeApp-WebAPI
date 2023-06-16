using CafeApp.Models;
using CafeApp.Models.Order;
using Microsoft.EntityFrameworkCore;

namespace CafeApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MenuItem> Menu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { Id = 1, Name = "Restaurant 1", City = "City 1" },
                new Restaurant { Id = 2, Name = "Restaurant 2", City = "City 2", IsOpen = false },
                new Restaurant { Id = 3, Name = "Restaurant 3", City = "City 3", IsOpen = false },
                new Restaurant { Id = 4, Name = "Restaurant 4", City = "City 4" },
                new Restaurant { Id = 5, Name = "Restaurant 5", City = "City 5" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
