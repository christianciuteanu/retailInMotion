using MediatR;
using RetailInMotion.OrdersManagement.Core.Aggregates;
using RetailInMotion.OrdersManagement.Core.Commands;
using RetailInMotion.OrdersManagement.Core.Interfaces;

namespace RetailInMotion.OrdersManagement.Core.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Unit>
    {
        private readonly IRepository<Order> _repository;

        public CreateOrderHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _repository.InsertAsync(new Order(request.Order.Id, request.Order.ProductName));
            
            return await Task.FromResult(Unit.Value);
        }
    }
}
 