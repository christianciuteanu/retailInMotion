using MediatR;
using RetailInMotion.OrdersManagement.Core.Aggregates;

namespace RetailInMotion.OrdersManagement.Core.Commands
{
    internal class UpdateOrderDeliveryAddressCommand : IRequest<Unit>
    {
        public Order Order { get; private set; }

        public UpdateOrderDeliveryAddressCommand(Guid orderId, string deliverAddress)
        {
            Order = new Order(orderId, deliverAddress);
        }
    }
}
