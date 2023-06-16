using MediatR;
using RetailInMotion.OrdersManagement.Core.Commands;
using RetailInMotion.OrdersManagement.Infrastructure.Persistance;

namespace RetailInMotion.OrdersManagement.Core.Handlers
{
    internal class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IOrderRepository _repository;

        public DeleteOrderCommandHandler(IOrderRepository repository)
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
