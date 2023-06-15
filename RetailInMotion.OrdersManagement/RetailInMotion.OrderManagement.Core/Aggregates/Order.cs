using RetailInMotion.OrdersManagement.SharedKernel;
using RetailInMotion.OrdersManagement.SharedKernel.Interfaces;

namespace RetailInMotion.OrdersManagement.Core.Aggregates
{
    public class Order : BaseEntity<Guid>, IAggregateRoot
    {
        public string ProductName { get; private set; }

        public Order() { }
        public Order(Guid id, string productName)
        {
            Id = id;
            ProductName = productName;
        }
    }
}
