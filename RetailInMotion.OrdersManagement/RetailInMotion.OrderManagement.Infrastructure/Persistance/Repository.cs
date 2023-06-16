using Microsoft.EntityFrameworkCore;
using RetailInMotion.OrdersManagement.Core.Aggregates;
using RetailInMotion.OrdersManagement.Core.Interfaces;
using RetailInMotion.OrdersManagement.SharedKernel.Interfaces;
using System.Linq.Expressions;

namespace RetailInMotion.OrdersManagement.Infrastructure.Persistance
{
    internal class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        protected readonly OrdersDbContext Context;
        private readonly DbSet<T> _dbSet;

        public Repository()
        {
            Context = new OrdersDbContext();
            _dbSet = Context.Set<T>();
        }
        public async Task DeleteAsync(Guid id)
        {
            Context.Orders.Remove(new Order());

            await Context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() =>
            await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(Guid id) =>
            await _dbSet.FindAsync(id).AsTask();

        public async Task InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T Entity)
        {
            _dbSet.Update(Entity);

            await Context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task UpdateColumnAsync(T entity, Expression<Func<T, object>> propertyExpression, object value)
        {
            var propName = Repository<T>.GetPropertyName(propertyExpression);

            Context.Attach(entity);
            Context.Entry(entity).Property(propName).IsModified = true;
            Context.Entry(entity).Property(propName).CurrentValue = value;

            await Context.SaveChangesAsync();
        }

        public IQueryable<T> Include(params Expression<Func<T, object>>[] includProps)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            return includProps.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        private static string GetPropertyName(Expression<Func<T, object>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            throw new ArgumentException("Invalid property expression");
        }
    }
}
