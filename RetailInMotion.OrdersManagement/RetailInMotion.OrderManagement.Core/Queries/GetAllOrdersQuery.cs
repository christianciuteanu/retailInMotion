using MediatR;
using RetailInMotion.OrdersManagement.Core.Aggregates;

namespace RetailInMotion.OrdersManagement.Core.Queries
{
    internal class GetAllOrdersQuery : IRequest<IEnumerable<Order>> { }
}
