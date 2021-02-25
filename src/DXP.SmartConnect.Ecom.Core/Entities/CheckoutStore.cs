using DXP.SmartConnect.Ecom.SharedKernel;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CheckoutStore : BaseEntity<string>
    {
        public string Name { set; get; }
        public CheckoutStoreAddress Address { set; get; }
    }
}
