using DXP.SmartConnect.Ecom.SharedKernel;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CheckoutPaymentMethodExpire : BaseEntity<string>
    {
        public int Year { set; get; }
        public int Month { set; get; }
    }
}
