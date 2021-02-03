using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.SharedKernel.Interfaces
{
    public interface IRepository<T, TId> where T : BaseEntity<TId>, IAggregateRoot
    {
        T Get(object id);
        T GetByComposite(params object[] ids);
        Task<T> GetAsync(TId id);
        IQueryable<T> GetAll();
        Task<List<T>> GetAllAsync();
        T Add(T entity);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
        void Commit();
        Task CommitAsync();
        void LoadCollection(T entity, string propertyName);
        Task LoadCollectionAsync(T entity, string propertyName);
        void Reload(T entity);
        Task ReloadAsync(T entity);
        void CommitAndReload(T entity);
        Task CommitAndReloadAsync(T entity);
    }
}