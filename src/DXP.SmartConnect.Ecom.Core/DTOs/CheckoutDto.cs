using DXP.SmartConnect.Ecom.Core.Entities;
using System.Collections.Generic;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class CheckoutDto
    {
        public CheckoutStoreDto Store { set; get; }
        public CheckoutFulfilmentDto Fulfilment { set; get; }
        public string OrderReference { set; get; }
        public string NotificationPhoneNumber { set; get; }
        public CheckoutPaymentMethodDto PaymentMethod { set; get; }
        public IList<string> PromoCodes { set; get; }
        public string Notes { set; get; }

        /// <summary>
        /// Transform object from type Checkout to type CheckoutDto
        /// </summary>
        /// <returns>CheckoutDto</returns>
        public static CheckoutDto FromCheckout(Checkout item)
        {
            if (item != null)
            {
                return new CheckoutDto()
                {
                    OrderReference = item.OrderReference,
                    NotificationPhoneNumber = item.NotificationPhoneNumber,
                    PromoCodes = item.PromoCodes,
                    Notes = item.Notes,
                    PaymentMethod = CheckoutPaymentMethodDto.FromCheckoutPaymentMethod(item.PaymentMethod),
                    Store = CheckoutStoreDto.FromCheckoutStore(item.Store),
                    Fulfilment = CheckoutFulfilmentDto.FromCheckoutFulfilment(item.Fulfilment)
                };
            }
            return null;
        }
    }
}
