using MediatR;

namespace RetailInMotion.OrdersManagement.Core.Commands
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public Guid Id { get; }

        public DeleteOrderCommand(Guid id)
        {
            Id = id;
        }
    }
}
