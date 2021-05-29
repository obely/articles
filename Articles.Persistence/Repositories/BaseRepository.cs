using Articles.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Articles.Persistence.Repositories
{
    class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly ArticlesDbContext _dbContext;

        public BaseRepository(ArticlesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(SortOptions sortOptions, PaginationOptions paginationOptions)
        {
            var query = _dbContext.Set<T>().AsQueryable<T>();

            if (sortOptions != null)
            {
                string sortingMethod = sortOptions.Ascending ? nameof(Enumerable.OrderBy) : nameof(Enumerable.OrderByDescending);
                var param = Expression.Parameter(typeof(T), sortOptions.SortKey);
                var pi = typeof(T).GetProperty(sortOptions.SortKey);
                var types = new Type[] { typeof(T), pi.PropertyType };

                var expr = Expression.Call(typeof(Queryable), sortingMethod, types, query.Expression, Expression.Lambda(Expression.Property(param, sortOptions.SortKey), param));
                query = query.Provider.CreateQuery<T>(expr);
            }

            if (paginationOptions != null)
            {
                query = query.Skip((paginationOptions.Page - 1) * paginationOptions.Size).Take(paginationOptions.Size);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
