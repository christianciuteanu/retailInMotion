using Microsoft.EntityFrameworkCore;
using RetailInMotion.OrdersManagement.Core.Aggregates;

namespace RetailInMotion.OrdersManagement.Infrastructure.Persistance
{
    public class OrdersDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "OrdersDb");
        }
        public DbSet<Order> Orders { get; set; }
    }
}
