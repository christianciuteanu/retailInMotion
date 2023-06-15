namespace RetailInMotion.OrdersManagement.Api.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; } = default!;

        public string ProductName { get; set; } = default!;
    }
}
