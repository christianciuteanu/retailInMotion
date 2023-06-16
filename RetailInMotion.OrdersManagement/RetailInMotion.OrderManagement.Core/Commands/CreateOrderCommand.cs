using MediatR;
using RetailInMotion.OrdersManagement.Core.DTOs;
using RetailInMotion.OrdersManagement.Core.Enums;

namespace RetailInMotion.OrdersManagement.Core.Commands
{
    internal record CreateOrderCommand : IRequest<Unit>
    {
        public string DeliveryAddress { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }

        public OrderStatus OrderStatus{ get; set; }

        public CreateOrderCommand(string deliveryAddress, IEnumerable<ProductDTO> productDTOs)
        {
            DeliveryAddress = deliveryAddress;
            Products = productDTOs;
            OrderStatus = OrderStatus.Pending;
        }
    }
}
