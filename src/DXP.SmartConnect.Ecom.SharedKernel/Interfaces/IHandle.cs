using DXP.SmartConnect.Ecom.SharedKernel;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.SharedKernel.Interfaces
{
    public interface IHandle<in T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}