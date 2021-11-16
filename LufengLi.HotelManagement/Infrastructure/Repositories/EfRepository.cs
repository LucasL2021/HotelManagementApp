using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.Helpers;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly HotelManagementDbContext hotelManagementDbContext;

        public EfRepository(HotelManagementDbContext dbContext)
        {
            hotelManagementDbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await hotelManagementDbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await hotelManagementDbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAllWithIncludesAsync(Expression<Func<T, bool>> where,
            params Expression<Func<T, object>>[] includes)
        {
            var query = hotelManagementDbContext.Set<T>().AsQueryable();

            if (includes != null)
                foreach (var navigationProperty in includes)
                    query = query.Include(navigationProperty);

            return await query.Where(where).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter)
        {
            return await hotelManagementDbContext.Set<T>().Where(filter).ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            hotelManagementDbContext.Set<T>().Add(entity);
            await hotelManagementDbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            hotelManagementDbContext.Entry(entity).State = EntityState.Modified;
            await hotelManagementDbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            hotelManagementDbContext.Set<T>().Remove(entity);
            await hotelManagementDbContext.SaveChangesAsync();
        }

        public virtual async Task<PaginatedList<T>> GetPagedData(int page = 1, int pageSize = 25,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderedQuery
                = null, Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            var pagedList =
                await PaginatedList<T>.GetPaged(hotelManagementDbContext.Set<T>(), page, pageSize, orderedQuery, filter, includes);
            return pagedList;
        }
    }
}