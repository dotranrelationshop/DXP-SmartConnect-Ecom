using DXP.SmartConnect.Ecom.SharedKernel;
using DXP.SmartConnect.Ecom.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Infrastructure.Data.Database
{
    public abstract class EfRepository<C, T, TId> : IRepository<T, TId>
        where TId : IEquatable<TId>
        where T : BaseEntity<TId>, IAggregateRoot
        where C : DbContext, new()
    {
        protected readonly C _dbContext;

        protected EfRepository(C dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<T> GetAsync(TId id)
        {
            return _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id.Equals(id));
        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
