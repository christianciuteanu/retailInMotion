using MediatR;

namespace RetailInMotion.OrdersManagement.Core.Commands
{
    internal record DeleteOrderCommand : IRequest<Unit>
    {
        public Guid Id { get; }

        public DeleteOrderCommand(Guid id)
        {
            Id = id;
        }
    }
}
