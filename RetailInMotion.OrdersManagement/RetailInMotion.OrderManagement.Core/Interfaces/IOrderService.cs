using RetailInMotion.OrdersManagement.Api.DTOs;
using RetailInMotion.OrdersManagement.Core.DTOs;

namespace RetailInMotion.OrdersManagement.Core.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(OrderDTO orderDTO);

        Task<IEnumerable<OrderDTO>> GetAllAsync();

        Task<OrderDTO> GetByIdAsync(Guid orderId);

        Task DeleteAsync(Guid id);

        Task UpdateDeliveryAddressAsync(Guid orderId, string deliveryAddress);

        Task UpdateProductsAsync(Guid orderId, IEnumerable<ProductDTO> productDTOs);
    }
}
