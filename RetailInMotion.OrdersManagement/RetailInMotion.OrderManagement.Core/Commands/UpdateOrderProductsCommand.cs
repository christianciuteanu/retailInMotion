using MediatR;
using RetailInMotion.OrdersManagement.Core.Entities;

namespace RetailInMotion.OrdersManagement.Core.Commands
{
    internal class UpdateOrderProductsCommand : IRequest<Unit> 
    {
        public Guid OrderId { get; private set; }
        public IEnumerable<Product> Products { get; private set; }

        public UpdateOrderProductsCommand(Guid orderId, IEnumerable<Product> products)
        {
            OrderId = orderId;
            Products = products;
        }
    }
}
