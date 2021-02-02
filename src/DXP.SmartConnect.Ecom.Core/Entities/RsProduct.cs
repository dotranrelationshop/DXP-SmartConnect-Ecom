using DXP.SmartConnect.Ecom.SharedKernel;
using DXP.SmartConnect.Ecom.SharedKernel.Interfaces;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class RsProduct : BaseEntity<int>, IAggregateRoot
    {
        public string ProductId { set; get; }
        public string Sku { set; get; }
        public string Name { set; get; }
    }
}