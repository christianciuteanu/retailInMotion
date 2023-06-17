using MediatR;
using RetailInMotion.OrdersManagement.Core.Commands;
using RetailInMotion.OrdersManagement.Infrastructure.Persistance;

namespace RetailInMotion.OrdersManagement.Core.Handlers
{
    internal class UpdateOrderDeliveryAddressCommandHandler : IRequestHandler<UpdateOrderDeliveryAddressCommand, Unit>
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderDeliveryAddressCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateOrderDeliveryAddressCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateColumnAsync(
                request.Order,
                o => o.DeliveryAddress,
                request.Order.DeliveryAddress,
                cancellationToken
            );

            return await Task.FromResult(Unit.Value);
        }
    }
}
