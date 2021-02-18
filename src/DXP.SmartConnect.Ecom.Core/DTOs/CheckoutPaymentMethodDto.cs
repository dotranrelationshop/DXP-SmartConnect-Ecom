using DXP.SmartConnect.Ecom.Core.Entities;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class CheckoutPaymentMethodDto
    {
        public CustomerAddressDto BillingAddress { set; get; }
        public string CardIssuer { set; get; }
        public string FourDigitCardMask { set; get; }
        public string NameOnCard { set; get; }
        public string PaymentToken { set; get; }
        public string Type { set; get; }
        public CheckoutPaymentMethodExpireDto Expires { set; get; }

        /// <summary>
        /// Transform object from type CheckoutPaymentMethod to type CheckoutPaymentMethodDto
        /// </summary>
        /// <returns>CheckoutPaymentMethodDto</returns>
        public static CheckoutPaymentMethodDto FromCheckoutPaymentMethod(CheckoutPaymentMethod item)
        {
            if (item != null)
            {
                return new CheckoutPaymentMethodDto()
                {
                    CardIssuer = item.CardIssuer,
                    FourDigitCardMask = item.FourDigitCardMask,
                    NameOnCard = item.NameOnCard,
                    PaymentToken = item.PaymentToken,
                    Type = item.Type,
                    BillingAddress = CustomerAddressDto.FromCustomerAddress(item.BillingAddress),
                    Expires = CheckoutPaymentMethodExpireDto.FromCheckoutPaymentMethodExpire(item.Expires)
                };
            }
            return null;
        }
    }
}