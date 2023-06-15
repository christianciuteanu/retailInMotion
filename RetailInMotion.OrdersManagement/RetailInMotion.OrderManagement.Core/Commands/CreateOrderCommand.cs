using MediatR;
using RetailInMotion.OrdersManagement.Core.Aggregates;

namespace RetailInMotion.OrdersManagement.Core.Commands
{
    public record CreateOrderCommand : IRequest<Unit>
    {
        public Order Order { get; set; }

        public CreateOrderCommand(Order order)
        {
            Order = order;
        }
    }
}
