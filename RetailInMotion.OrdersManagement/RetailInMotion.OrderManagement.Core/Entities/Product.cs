using RetailInMotion.OrdersManagement.Core.Aggregates;
using RetailInMotion.OrdersManagement.SharedKernel;

namespace RetailInMotion.OrdersManagement.Core.Entities
{
    public class Product : BaseEntity<Guid>
    {
        public string ProductName { get; set; } = default!;
    }
}
