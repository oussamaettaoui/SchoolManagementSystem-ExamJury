using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.IRepositories;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Props
        private readonly AppDbContext _db;
        internal DbSet<T> dbSet;
        #endregion
        #region Constructor
        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        #endregion
        #region Methods
        public async Task<List<T>> GetAllAsNoTracking(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }
        public async Task<T> GetAsNoTracking(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }
        public async Task<List<T>> GetAllAsTracking(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet.AsTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }
        public async Task<T> GetAsTracking(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet.AsTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }
        public async Task CreateRangeAsync(ICollection<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }
        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
        }
        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);
        }
        #endregion
    }
}
