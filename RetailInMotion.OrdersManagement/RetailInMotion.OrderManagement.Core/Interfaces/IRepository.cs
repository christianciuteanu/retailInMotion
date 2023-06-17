using RetailInMotion.OrdersManagement.SharedKernel.Interfaces;
using System.Linq.Expressions;

namespace RetailInMotion.OrdersManagement.Core.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task InsertAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task UpdateColumnAsync(T entity, Expression<Func<T, object>> propertyExpression, object value, CancellationToken cancellationToken);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
        IQueryable<T> Include(params Expression<Func<T, object>>[] includProps);
    }
}
