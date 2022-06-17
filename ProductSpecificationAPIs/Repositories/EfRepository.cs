using Microsoft.EntityFrameworkCore;
using ProductCodeOldAPIs.Models;
using ProductCodeOldAPIs.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ProductCodeOldAPIs.Repositories
{
    public class EfRepository<T> : IEfRepository<T> where T : BaseEntity
    {
        protected ProductSpDbContext context;
        public IQueryable<T> Table { get => context.Set<T>().AsQueryable(); }
        public EfRepository(ProductSpDbContext dbContext)
        {
            context = dbContext;
        }
        public async Task<bool> AddRangeAsync(List<T> entity)
        {
            context.Set<T>().AddRange(entity);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AddAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<T> FindByIdAsync(object id) => await context.Set<T>().FindAsync(id);
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) => await context.Set<T>().FirstOrDefaultAsync(predicate);
        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate) => context.Set<T>().Where(predicate).AsEnumerable();
    }
}
