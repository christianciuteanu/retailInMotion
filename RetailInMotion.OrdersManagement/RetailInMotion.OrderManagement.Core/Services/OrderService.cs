using AutoMapper;
using MediatR;
using RetailInMotion.OrdersManagement.Api.DTOs;
using RetailInMotion.OrdersManagement.Core.Commands;
using RetailInMotion.OrdersManagement.Core.DTOs;
using RetailInMotion.OrdersManagement.Core.Entities;
using RetailInMotion.OrdersManagement.Core.Handlers;
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
        public async Task CreateAsync(OrderDTO order)
            => await _mediator.Send(new CreateOrderCommand(order.DeliveryAddress, order.Products));

        public async Task DeleteAsync(Guid id)
            => await _mediator.Send(new DeleteOrderCommand(id));

        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
            => _mapper.Map<IEnumerable<OrderDTO>>(await _mediator.Send(new GetAllOrdersQuery()));

        public async Task<OrderDTO> GetByIdAsync(Guid id)
            => _mapper.Map<OrderDTO>(await _mediator.Send(new GetOrderByIdQuery(id)));

        public async Task UpdateDeliveryAddressAsync(Guid orderId, string deliveryAddress)
            => await _mediator.Send(new UpdateOrderDeliveryAddressCommand(orderId, deliveryAddress));

        public async Task UpdateProductsAsync(Guid orderId, IEnumerable<ProductDTO> productDTOs)
            => await _mediator.Send(new UpdateOrderProductsCommand(orderId, _mapper.Map<IEnumerable<Product>>(productDTOs)));
    }
}
