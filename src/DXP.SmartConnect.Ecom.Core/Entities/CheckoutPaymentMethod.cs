using DXP.SmartConnect.Ecom.SharedKernel;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CheckoutPaymentMethod : BaseEntity<string>
    {
        public CustomerAddress BillingAddress { set; get; }
        public string CardIssuer { set; get; }
        public string FourDigitCardMask { set; get; }
        public string NameOnCard { set; get; }
        public string PaymentToken { set; get; }
        public string Type { set; get; }
        public CheckoutPaymentMethodExpire Expires { set; get; }
    }
}
