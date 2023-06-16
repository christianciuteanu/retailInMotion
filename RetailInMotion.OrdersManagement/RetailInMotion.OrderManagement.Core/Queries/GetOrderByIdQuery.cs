using MediatR;
using RetailInMotion.OrdersManagement.Core.Aggregates;

namespace RetailInMotion.OrdersManagement.Core.Queries
{
    internal class GetOrderByIdQuery : IRequest<Order>
    {
        public Guid Id { get; }

        public GetOrderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
