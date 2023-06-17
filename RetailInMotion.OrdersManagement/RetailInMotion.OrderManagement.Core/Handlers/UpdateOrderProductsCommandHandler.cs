using MediatR;
using RetailInMotion.OrdersManagement.Core.Commands;
using RetailInMotion.OrdersManagement.Infrastructure.Persistance;

namespace RetailInMotion.OrdersManagement.Core.Handlers
{
    internal class UpdateOrderProductsCommandHandler : IRequestHandler<UpdateOrderProductsCommand, Unit>
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderProductsCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateOrderProductsCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateOrderProductsAsync(request.OrderId, request.Products, cancellationToken);

            return await Task.FromResult(Unit.Value);
        }
    }
}
