using RetailInMotion.OrdersManagement.Core.Entities;
using RetailInMotion.OrdersManagement.Core.Enums;
using RetailInMotion.OrdersManagement.SharedKernel;
using RetailInMotion.OrdersManagement.SharedKernel.Interfaces;

namespace RetailInMotion.OrdersManagement.Core.Aggregates
{
    public class Order : BaseEntity<Guid>, IAggregateRoot
    {
        public string DeliveryAddress { get; private set; }

        public ICollection<Product> Products { get; private set; }
        public OrderStatus Status { get; private set; }

        public Order() { }

        public Order(Guid id)
        {
            Id = id;
        }

        public Order(Guid id, OrderStatus status) : this(id)
        {
            Status = status;
        }

        public Order(Guid id, string deliveryAddress) : this(id)
        {
            DeliveryAddress = deliveryAddress;
        }

        public Order(string deliveryAddress, IEnumerable<Product> products, OrderStatus orderStatus)
        {
            Id = Guid.NewGuid();
            DeliveryAddress = deliveryAddress;
            Products = products.ToArray();
            Status = orderStatus;
        }
    }
}
