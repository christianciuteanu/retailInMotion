using AutoMapper;
using MediatR;
using RetailInMotion.OrdersManagement.Api.DTOs;
using RetailInMotion.OrdersManagement.Core.Commands;
using RetailInMotion.OrdersManagement.Core.DTOs;
using RetailInMotion.OrdersManagement.Core.Entities;
using RetailInMotion.OrdersManagement.Core.Interfaces;
using RetailInMotion.OrdersManagement.Core.Queries;

namespace RetailInMotion.OrdersManagement.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public OrderService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateOrderDTO order, CancellationToken cancellationToken)
            => await _mediator.Send(new CreateOrderCommand(order.DeliveryAddress, order.Products), cancellationToken);

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
            => await _mediator.Send(new DeleteOrderCommand(id), cancellationToken);

        public async Task<IEnumerable<OrderDTO>> GetAllAsync(CancellationToken cancellationToken)
            => _mapper.Map<IEnumerable<OrderDTO>>(await _mediator.Send(new GetAllOrdersQuery(), cancellationToken));

        public async Task<OrderDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => _mapper.Map<OrderDTO>(await _mediator.Send(new GetOrderByIdQuery(id), cancellationToken));

        public async Task UpdateDeliveryAddressAsync(Guid orderId, string deliveryAddress, CancellationToken cancellationToken)
            => await _mediator.Send(new UpdateOrderDeliveryAddressCommand(orderId, deliveryAddress), cancellationToken);

        public async Task UpdateProductsAsync(Guid orderId, IEnumerable<ProductDTO> productDTOs, CancellationToken cancellationToken)
            => await _mediator.Send(new UpdateOrderProductsCommand(orderId, _mapper.Map<IEnumerable<Product>>(productDTOs)), cancellationToken);

        public async Task CancelAsync(Guid orderId, CancellationToken cancellationToken)
            => await _mediator.Send(new CancelOrderCommand(orderId), cancellationToken);
    }
}
