using Microsoft.EntityFrameworkCore;
using RetailInMotion.OrdersManagement.Core.Aggregates;
using RetailInMotion.OrdersManagement.Core.Entities;

namespace RetailInMotion.OrdersManagement.Infrastructure.Persistance
{
    internal class OrderRepository : Repository<Order>, IOrderRepository
    {
        public async Task CancelAsync(Guid orderId, CancellationToken cancellationToken)
        {
            var order = new Order(orderId, Core.Enums.OrderStatus.Canceled);

            Context.Orders.Attach(order);
            Context.Entry(order).Property(p => p.Status).IsModified = true;

            await SaveAsync(cancellationToken);
        }

        public async override Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await Include(o => o.Products).ToListAsync(cancellationToken);
        }

        public async Task UpdateOrderProductsAsync(Guid orderId, IEnumerable<Product> products, CancellationToken cancellationToken)
        {
            var order = new Order(orderId);

            Context.Orders.Attach(order);

            Context.Entry(order).Collection(o => o.Products).Load();

            order.Products.Clear();

            foreach (var item in products)
            {
                order.Products.Add(item);
            }

            await SaveAsync(cancellationToken);
        }
    }
}
