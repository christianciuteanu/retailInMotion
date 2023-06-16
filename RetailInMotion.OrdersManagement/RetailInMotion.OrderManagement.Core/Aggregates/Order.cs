using RetailInMotion.OrdersManagement.Core.Entities;
using RetailInMotion.OrdersManagement.Core.Enums;
using RetailInMotion.OrdersManagement.SharedKernel;
using RetailInMotion.OrdersManagement.SharedKernel.Interfaces;

namespace RetailInMotion.OrdersManagement.Core.Aggregates
{
    public class Order : BaseEntity<Guid>, IAggregateRoot
    {
        public string DeliveryAddress { get; private set; }
        
        // Note - Set should be private
        public IEnumerable<Product> Products { get; set; }
        public OrderStatus OrderStatus { get; private set; }

        public Order() { }

        public Order(Guid id, string deliveryAddress)
        {
            Id = id;
            DeliveryAddress = deliveryAddress;
        }

        public Order(string deliveryAddress, IEnumerable<Product> products, OrderStatus orderStatus)
        {
            Id = Guid.NewGuid();
            DeliveryAddress = deliveryAddress;
            Products = products;
            OrderStatus = orderStatus;
        }

        public Order(Guid id, IEnumerable<Product> products)
        {
            Id = id;
            Products = products;
        }
    }
}
