using DXP.SmartConnect.Ecom.SharedKernel;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CartTax : BaseEntity<string>
    {
        public string GroupName { set; get; }
        public decimal Amount { set; get; }
    }
}