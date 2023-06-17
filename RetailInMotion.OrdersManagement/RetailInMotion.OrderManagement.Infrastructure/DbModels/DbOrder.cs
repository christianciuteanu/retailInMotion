using RetailInMotion.OrdersManagement.Core.Entities;
using RetailInMotion.OrdersManagement.Core.Enums;

namespace RetailInMotion.OrdersManagement.Infrastructure.DbModels
{
    internal class DbOrder : DbBaseEntity<Guid>
    {
        public string DeliveryAddress { get; set; }
        public ICollection<Product> Products { get; set; }
        public OrderStatus Status { get; set; }
    }
}
