using MediatR;
using RetailInMotion.OrdersManagement.Core.Aggregates;
using RetailInMotion.OrdersManagement.Core.Queries;
using RetailInMotion.OrdersManagement.Infrastructure.Persistance;

namespace RetailInMotion.OrdersManagement.Core.Handlers
{
    internal class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderRepository _repository;

        public GetOrderByIdQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
            => await _repository.GetByIdAsync(request.Id);
    }
}
