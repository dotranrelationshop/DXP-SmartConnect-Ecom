using DXP.SmartConnect.Ecom.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Core.Interfaces
{
    public interface ICheckoutWebApiClient
    {
        /// <summary>
        /// Get customer checkout info.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <returns>Checkout info</returns>
        Task<Checkout> GetCheckoutInfo(string accessToken, string storeId);
        /// <summary>
        /// Get available time slots for checkout.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="shoppingModeId">Shopping mode Id </param>
        /// <param name="startPage">Start page </param>
        /// <returns>Available time slots</returns>
        Task<TimeSlotsPage> GetAvailableTimeSlots(string accessToken, string storeId, string shoppingModeId, int startPage = 0);
        /// <summary>
        /// Get current reservation slot for checkout.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="uiDateTimeOffsetInMinutes">Time offset in minutes </param>
        /// <returns>Reservation slot</returns>
        Task<TimeSlotReservation> GetCurrentReservation(string accessToken, string storeId, string uiDateTimeOffsetInMinutes);
        /// <summary>
        /// Select reservation slot for checkout.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="reservationId">Slot Id </param>
        /// <returns>Status of command</returns>
        Task<bool> SelectTimeSlot(string accessToken, string storeId, string reservationId);
        /// <summary>
        /// Get payment method for checkout.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <returns>Payment method</returns>
        Task<PaymentMethod> GetPaymentMethod(string accessToken, string storeId);
        /// <summary>
        /// Get customer delivery and billing address for checkout.
        /// </summary>
        /// <returns>List address</returns>
        Task<CustomerAddress> GetCustomerAddress(string accessToken);
        /// <summary>
        /// Get customer credit card info for checkout.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <returns>Credit card info</returns>
        Task<IList<PaymentCustomerCard>> GetCustomerPaymentCards(string accessToken, string storeId);
        /// <summary>
        /// Remove customer credit card.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="cardType">Card type </param>
        /// <param name="cardNumber">Masked Card number (xxxxx1234) </param>
        /// <returns>Status of command</returns>
        Task<bool> RemoveCustomerPaymentCard(string accessToken, string storeId, string cardType, string cardNumber);
        /// <summary>
        /// Add promo code for checkout.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="promoCode">Promo code </param>
        /// <returns>Status of command</returns>
        Task<bool> AddPromoCode(string accessToken, string storeId, string promoCode);
        /// <summary>
        /// Add comment for checkout.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="notes">Comment </param>
        /// <returns>Status of command</returns>
        Task<bool> AddCommnent(string accessToken, string storeId, string notes);
    }
}
