using DXP.SmartConnect.Ecom.SharedKernel;
using System.Collections.Generic;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class Checkout : BaseEntity<string>
    {
        public CheckoutStore Store { set; get; }
        public CheckoutFulfilment Fulfilment { set; get; }
        public string OrderReference { set; get; }
        public string NotificationPhoneNumber { set; get; }
        public CheckoutPaymentMethod PaymentMethod { set; get; }
        public IList<string> PromoCodes { set; get; }
        public string Notes { set; get; }
    }
}
