using MediatR;

namespace RetailInMotion.OrdersManagement.Core.Commands
{
    internal class CancelOrderCommand : IRequest<Unit>
    {
        public Guid Id { get; private set; }

        public CancelOrderCommand(Guid id)
        {
            Id = id;
        }
    }
}
