using System.Collections.Generic;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.SharedKernel.Interfaces
{
    public interface IRepository<T, TId> where T : BaseEntity<TId>, IAggregateRoot
    {
        Task<T> GetAsync(TId id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task CommitAsync();
    }
}