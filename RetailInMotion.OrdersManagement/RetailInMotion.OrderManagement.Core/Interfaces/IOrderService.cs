using RetailInMotion.OrdersManagement.Api.DTOs;
using RetailInMotion.OrdersManagement.Core.DTOs;

namespace RetailInMotion.OrdersManagement.Core.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(CreateOrderDTO orderDTO, CancellationToken cancellationToken);

        Task<IEnumerable<OrderDTO>> GetAllAsync(CancellationToken cancellationToken);

        Task<OrderDTO> GetByIdAsync(Guid orderId, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        Task UpdateDeliveryAddressAsync(Guid orderId, string deliveryAddress, CancellationToken cancellationToken);

        Task UpdateProductsAsync(Guid orderId, IEnumerable<ProductDTO> productDTOs, CancellationToken cancellationToken);

        Task CancelAsync(Guid orderId, CancellationToken cancellationToken);
    }
}
