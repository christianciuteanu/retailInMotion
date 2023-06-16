using Microsoft.EntityFrameworkCore;
using RetailInMotion.OrdersManagement.Core.Aggregates;
using RetailInMotion.OrdersManagement.Core.Entities;

namespace RetailInMotion.OrdersManagement.Infrastructure.Persistance
{
    internal class OrdersDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "OrdersDb");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(o => o.Id);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithOne();

            modelBuilder.Entity<Product>()
                .HasKey(o => o.Id);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
