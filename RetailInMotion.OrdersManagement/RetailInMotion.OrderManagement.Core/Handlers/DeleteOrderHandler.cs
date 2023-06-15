using MediatR;
using RetailInMotion.OrdersManagement.Core.Aggregates;
using RetailInMotion.OrdersManagement.Core.Commands;
using RetailInMotion.OrdersManagement.Core.Interfaces;

namespace RetailInMotion.OrdersManagement.Core.Handlers
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IRepository<Order> _repository;

        public DeleteOrderHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);

            return await Task.FromResult(Unit.Value);
        }
    }
}
