using DXP.SmartConnect.Ecom.SharedKernel;
using DXP.SmartConnect.Ecom.SharedKernel.Interfaces;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class RsProduct : BaseEntity<int>, IAggregateRoot
    {
        public string Name { set; get; }
    }
}