using DXP.SmartConnect.Ecom.SharedKernel;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.SharedKernel.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent domainEvent);
    }
}