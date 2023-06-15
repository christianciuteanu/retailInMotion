using MediatR;
using RetailInMotion.OrdersManagement.Core.Aggregates;

namespace RetailInMotion.OrdersManagement.Core.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>> { }
}
