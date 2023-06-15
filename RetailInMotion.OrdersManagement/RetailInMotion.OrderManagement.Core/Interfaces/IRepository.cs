using RetailInMotion.OrdersManagement.SharedKernel.Interfaces;

namespace RetailInMotion.OrdersManagement.Core.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task SaveAsync();
    }
}
