using RetailInMotion.OrdersManagement.Core.Aggregates;
using RetailInMotion.OrdersManagement.Core.Entities;
using RetailInMotion.OrdersManagement.Core.Interfaces;

namespace RetailInMotion.OrdersManagement.Infrastructure.Persistance
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task UpdateOrderProductsAsync(Guid orderId, IEnumerable<Product> products);
    }
}
