using RetailInMotion.OrdersManagement.SharedKernel.Interfaces;
using System.Linq.Expressions;

namespace RetailInMotion.OrdersManagement.Core.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateColumnAsync(T entity, Expression<Func<T, object>> propertyExpression, object value);
        Task DeleteAsync(Guid id);
        Task SaveAsync();
        IQueryable<T> Include(params Expression<Func<T, object>>[] includProps);
    }
}
