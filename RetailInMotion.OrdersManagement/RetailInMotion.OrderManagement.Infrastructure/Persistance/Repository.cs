using Microsoft.EntityFrameworkCore;
using RetailInMotion.OrdersManagement.Core.Aggregates;
using RetailInMotion.OrdersManagement.Core.Interfaces;

namespace RetailInMotion.OrdersManagement.Infrastructure.Persistance
{
    internal class Repository<T> : IRepository<T> where T : Order
    {
        private readonly OrdersDbContext _context;
        private readonly DbSet<T> table;

        public Repository()
        {
            _context = new OrdersDbContext();
            table = _context.Set<T>();
        }
        public async Task DeleteAsync(Guid id)
        {
            _context.Orders.Remove(new Order(id, string.Empty));

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await table.ToListAsync();


        public async Task<T> GetByIdAsync(Guid id) =>
            await table.FindAsync(id).AsTask();

        public async Task InsertAsync(T entity)
        {
            await table.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T Entity)
        {
            table.Update(Entity);

            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
