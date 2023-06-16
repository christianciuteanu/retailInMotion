using RetailInMotion.OrdersManagement.Core.DTOs;

namespace RetailInMotion.OrdersManagement.Api.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public string DeliveryAddress { get; set; } = default!;
        public IEnumerable<ProductDTO> Products { get; set; } = default!;
    }
}
