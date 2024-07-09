using System.Linq.Expressions;

namespace SchoolManagementSystem.Application.IRepositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAsNoTracking();
        IQueryable<T> GetAsTracking();
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task CreateRangeAsync(ICollection<T> entities);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
