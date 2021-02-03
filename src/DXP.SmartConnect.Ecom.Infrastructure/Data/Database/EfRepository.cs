using DXP.SmartConnect.Ecom.SharedKernel;
using DXP.SmartConnect.Ecom.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public T Get(object id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T GetByComposite(params object[] ids)
        {
            return _dbContext.Set<T>().Find(ids);
        }

        public Task<T> GetAsync(TId id)
        {
            return _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id.Equals(id));
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = _dbContext.Set<T>();
            return query;
        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            _dbContext.Entry(entity).State = EntityState.Unchanged;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public void LoadCollection(T entity, string propertyName)
        {
            if (entity != null)
            {
                _dbContext.Entry(entity).Collection(propertyName).Load();
            }
        }

        public async Task LoadCollectionAsync(T entity, string propertyName)
        {
            if (entity != null)
            {
                await _dbContext.Entry(entity).Collection(propertyName).LoadAsync();
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public Task CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Reload(T entity)
        {
            if (entity != null)
            {
                _dbContext.Entry(entity).Reload();
            }
        }

        public async Task ReloadAsync(T entity)
        {
            if (entity != null)
            {
                await _dbContext.Entry(entity).ReloadAsync();
            }
        }

        public void CommitAndReload(T entity)
        {
            _dbContext.SaveChanges();
            if (entity != null)
            {
                _dbContext.Entry(entity).Reload();
            }
        }

        public async Task CommitAndReloadAsync(T entity)
        {
            await _dbContext.SaveChangesAsync();
            if (entity != null)
            {
                await _dbContext.Entry(entity).ReloadAsync();
            }
        }
    }
}
