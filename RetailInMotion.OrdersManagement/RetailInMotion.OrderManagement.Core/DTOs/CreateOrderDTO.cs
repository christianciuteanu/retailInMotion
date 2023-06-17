using RetailInMotion.OrdersManagement.Core.DTOs;
using RetailInMotion.OrdersManagement.Core.Enums;

namespace RetailInMotion.OrdersManagement.Api.DTOs
{
    public class CreateOrderDTO
    {
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string DeliveryAddress { get; set; } = default!;
        public IEnumerable<ProductDTO> Products { get; set; } = default!;
    }
}
