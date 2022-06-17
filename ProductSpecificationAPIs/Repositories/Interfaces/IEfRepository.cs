using ProductCodeOldAPIs.Models;
using System.Linq.Expressions;

namespace ProductCodeOldAPIs.Repositories.Interfaces
{
    public interface IEfRepository<T> where T : BaseEntity
    {
        IQueryable<T> Table { get; }
        Task<T> FindByIdAsync(object id);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
