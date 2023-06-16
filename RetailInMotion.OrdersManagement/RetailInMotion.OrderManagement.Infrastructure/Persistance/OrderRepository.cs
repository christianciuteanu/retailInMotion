using Microsoft.EntityFrameworkCore;
using RetailInMotion.OrdersManagement.Core.Aggregates;
using RetailInMotion.OrdersManagement.Core.Entities;

namespace RetailInMotion.OrdersManagement.Infrastructure.Persistance
{
    internal class OrderRepository : Repository<Order>, IOrderRepository
    {
        public async override Task<IEnumerable<Order>> GetAllAsync()
        {
            return await Include(o => o.Products).ToListAsync();
        }

        public async Task UpdateOrderProductsAsync(Guid orderId, IEnumerable<Product> products)
        {
            var order = new Order(orderId, products);
            
            Context.Attach(order);

            order.Products = products;

            await Context.SaveChangesAsync();
        }
    }
}
