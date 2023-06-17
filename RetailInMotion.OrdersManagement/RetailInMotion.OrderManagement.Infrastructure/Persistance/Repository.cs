using Microsoft.EntityFrameworkCore;
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
        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Remove(entity);

            await Context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken) =>
            await _dbSet.ToListAsync(cancellationToken);

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            await _dbSet.FindAsync(id, cancellationToken).AsTask();

        public async Task InsertAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);

            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(T Entity, CancellationToken cancellationToken)
        {
            _dbSet.Update(Entity);

            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateColumnAsync(T entity, Expression<Func<T, object>> propertyExpression, object value, CancellationToken cancellationToken)
        {
            var propName = Repository<T>.GetPropertyName(propertyExpression);

            Context.Attach(entity);
            Context.Entry(entity).Property(propName).IsModified = true;
            Context.Entry(entity).Property(propName).CurrentValue = value;

            await Context.SaveChangesAsync(cancellationToken);
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
