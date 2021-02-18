using DXP.SmartConnect.Ecom.Core.DTOs;
using DXP.SmartConnect.Ecom.Core.Entities;
using DXP.SmartConnect.Ecom.Core.Interfaces;
using DXP.SmartConnect.Ecom.Core.Settings;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Core.Services
{
    public class CheckoutService : BaseService, ICheckoutService
    {
        private readonly ICheckoutWebApiClient _checkoutWebApiClient;
        private readonly ApplicationSettings _setting;

        public CheckoutService(ICheckoutWebApiClient checkoutWebApiClient, IOptions<ApplicationSettings> options)
        {
            _checkoutWebApiClient = checkoutWebApiClient;
            _setting = options.Value;
        }

        public async Task<bool> AddCommnent(string storeId, string notes)
        {
            return await _checkoutWebApiClient.AddCommnent(_setting.AccessToken, storeId, notes);
        }

        public async Task<bool> AddPromoCode(string storeId, string promoCode)
        {
            return await _checkoutWebApiClient.AddPromoCode(_setting.AccessToken, storeId, promoCode);
        }

        public async Task<TimeSlotsPageDto> GetAvailableSlots(string storeId, string shoppingModeId, int startPage)
        {
            var slotsPage = await _checkoutWebApiClient.GetAvailableTimeSlots(_setting.AccessToken, storeId, shoppingModeId, startPage);

            return TimeSlotsPageDto.FromTimeSlotsPage(slotsPage);
        }

        public async Task<CheckoutDto> GetCheckoutInfo(string storeId)
        {
            var checkoutInfo = await _checkoutWebApiClient.GetCheckoutInfo(_setting.AccessToken, storeId);

            return CheckoutDto.FromCheckout(checkoutInfo);
        }

        public async Task<TimeSlotReservationDto> GetCurrentReservation(string storeId, string uiDateTimeOffsetInMinutes)
        {
            var timeSlot = await _checkoutWebApiClient.GetCurrentReservation(_setting.AccessToken, storeId, uiDateTimeOffsetInMinutes);

            return TimeSlotReservationDto.FromTimeSlotReservation(timeSlot);
        }

        public async Task<IList<PaymentCustomerCardDto>> GetCustomerPaymentCards(string storeId)
        {
            var paymentCards = await _checkoutWebApiClient.GetCustomerPaymentCards(_setting.AccessToken, storeId);

            var paymentCardsDto = new List<PaymentCustomerCardDto>();

            if (paymentCards?.Any() ?? false)
            {
                foreach (var card in paymentCards)
                {
                    paymentCardsDto.Add(PaymentCustomerCardDto.FromPaymentCustomerCard(card));
                }
            }

            return paymentCardsDto;
        }

        public async Task<bool> RemoveCustomerPaymentCard(string storeId, string cardType, string cardNumber)
        {
            return await _checkoutWebApiClient.RemoveCustomerPaymentCard(_setting.AccessToken, storeId, cardType, cardNumber);
        }

        public async Task<bool> SelectSlot(string storeId, string reservationId)
        {
            return await _checkoutWebApiClient.SelectTimeSlot(_setting.AccessToken, storeId, reservationId);
        }
    }
}
