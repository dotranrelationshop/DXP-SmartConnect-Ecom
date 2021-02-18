using DXP.SmartConnect.Ecom.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Core.Interfaces
{
    public interface ICheckoutService
    {
        /// <summary>
        /// Get checkout info of user.
        /// </summary>
        /// <param name="storeId">The store id </param>
        /// <returns>The checkout out detail</returns>
        Task<CheckoutDto> GetCheckoutInfo(string storeId);
        /// <summary>
        /// Get available time slots.
        /// </summary>
        /// <param name="storeId">The store id </param>
        /// <param name="shoppingModeId">The shopping mode id </param>
        /// <param name="startPage">The page to start </param>
        /// <returns>The time slots page</returns>
        Task<TimeSlotsPageDto> GetAvailableSlots(string storeId, string shoppingModeId, int startPage);
        /// <summary>
        /// Get current reservation slot for checkout.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="uiDateTimeOffsetInMinutes">Time offset in minutes </param>
        /// <returns>Reservation slot</returns>
        Task<TimeSlotReservationDto> GetCurrentReservation(string storeId, string uiDateTimeOffsetInMinutes);
        /// <summary>
        /// Select time slots.
        /// </summary>
        /// <param name="storeId">The store id </param>
        /// <param name="reservationId">The shopping mode id </param>
        /// <returns>Status of command</returns>
        Task<bool> SelectSlot(string storeId, string reservationId);
        /// <summary>
        /// Get customer credit card info for checkout.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <returns>Credit card info</returns>
        Task<IList<PaymentCustomerCardDto>> GetCustomerPaymentCards(string storeId);
        /// <summary>
        /// Remove customer credit card.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="cardType">Card type </param>
        /// <param name="cardNumber">Masked Card number (xxxxx1234) </param>
        /// <returns>Status of command</returns>
        Task<bool> RemoveCustomerPaymentCard(string storeId, string cardType, string cardNumber);
        /// <summary>
        /// Add promo code for checkout.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="promoCode">Promo code </param>
        /// <returns>Status of command</returns>
        Task<bool> AddPromoCode(string storeId, string promoCode);
        /// <summary>
        /// Add comment for checkout.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="notes">Comment </param>
        /// <returns>Status of command</returns>
        Task<bool> AddCommnent(string storeId, string notes);
    }
}
