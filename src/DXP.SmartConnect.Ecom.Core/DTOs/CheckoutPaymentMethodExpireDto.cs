using DXP.SmartConnect.Ecom.Core.Entities;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class CheckoutPaymentMethodExpireDto
    {
        public int Year { set; get; }
        public int Month { set; get; }

        /// <summary>
        /// Transform object from type CheckoutPaymentMethodExpire to type CheckoutPaymentMethodExpireDto
        /// </summary>
        /// <returns>CheckoutPaymentMethodExpireDto</returns>
        public static CheckoutPaymentMethodExpireDto FromCheckoutPaymentMethodExpire(CheckoutPaymentMethodExpire item)
        {
            if (item != null)
            {
                return new CheckoutPaymentMethodExpireDto()
                {
                    Year = item.Year,
                    Month = item.Month
                };
            }
            return null;
        }
    }
}