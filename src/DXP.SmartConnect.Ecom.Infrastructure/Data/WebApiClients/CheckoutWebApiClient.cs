using DXP.SmartConnect.Ecom.Core.Entities;
using DXP.SmartConnect.Ecom.Core.Interfaces;
using DXP.SmartConnect.Ecom.Infrastructure.Constants;
using DXP.SmartConnect.Ecom.SharedKernel.WebApi;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Infrastructure.Data.WebApiClients
{
    public class CheckoutWebApiClient : WebApiClient, ICheckoutWebApiClient
    {
        private readonly ILogger<ProductWebApiClient> _logger;

        public CheckoutWebApiClient(ILogger<ProductWebApiClient> logger, HttpClient client) : base(logger, client)
        {
            _logger = logger;
        }

        public Task<bool> AddCommnent(string accessToken, string storeId, string notes)
        {
            var path = $"/stores/{storeId}/checkout";

            var body = new List<object> {
                new {
                    Op = WebApiClientCheckoutConstants.OptionReplace,
                    Path = WebApiClientCheckoutConstants.PathNotes,
                    Value = notes
                }
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, WebApiClientConstants.ApplicationJson);

            return PostAsync<bool>(path, HttpMethod.Patch, content, accessToken, null, HttpStatusSuccessCodes.CheckoutChange);
        }

        public Task<bool> AddCustomerPaymentCards(string accessToken, string storeId, string transactionId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddPromoCode(string accessToken, string storeId, string promoCode)
        {
            var path = $"/stores/{storeId}/checkout";

            var body = new List<object> {
                new {
                    Op = WebApiClientCheckoutConstants.OptionAdd,
                    Path = WebApiClientCheckoutConstants.PathPromoCode,
                    Value = promoCode
                }
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, WebApiClientConstants.ApplicationJson);

            return PostAsync<bool>(path, HttpMethod.Patch, content, accessToken, null, HttpStatusSuccessCodes.CheckoutChange);
        }

        public Task<TimeSlotsPage> GetAvailableTimeSlots(string accessToken, string storeId, string shoppingModeId, int startPage = 0)
        {
            var path = $"stores/{storeId}/shoppingmodes/{shoppingModeId}/timeslots/{startPage}";
            return GetAsync<TimeSlotsPage>(path, accessToken, null, HttpStatusSuccessCodes.GetCheckout);
        }

        public Task<Checkout> GetCheckoutInfo(string accessToken, string storeId)
        {
            var path = $"stores/{storeId}/checkout";
            return GetAsync<Checkout>(path, accessToken, null, HttpStatusSuccessCodes.GetCheckout);
        }

        public Task<TimeSlotReservation> GetCurrentReservation(string accessToken, string storeId, string uiDateTimeOffsetInMinutes)
        {
            var uiDatePath = string.IsNullOrEmpty(uiDateTimeOffsetInMinutes) ? "" : $"?uiDateTimeOffsetInMinutes={uiDateTimeOffsetInMinutes}";
            var path = $"stores/{storeId}/reservation{uiDatePath}";

            return GetAsync<TimeSlotReservation>(path, accessToken, null, HttpStatusSuccessCodes.GetCheckout);
        }

        public Task<CustomerAddress> GetCustomerAddress(string accessToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<PaymentCustomerCard>> GetCustomerPaymentCards(string accessToken, string storeId)
        {
            var path = $"/payments/{storeId}/customerCards";
            return await GetAsync<List<PaymentCustomerCard>>(path, accessToken, null, HttpStatusSuccessCodes.GetCheckout);
        }

        public Task<PaymentMethod> GetPaymentMethod(string accessToken, string storeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<PaymentTokenization> InitPaymentTokenization(string accessToken, string storeId, string transactionId, Payment payment)
        {
            var path = $"/payments/{storeId}/tokenization/tokenized-cards/transactions/{transactionId}";

            var content = new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, WebApiClientConstants.ApplicationJson);

            return PostAsync<PaymentTokenization>(path, HttpMethod.Put, content, accessToken, null, HttpStatusSuccessCodes.GetCheckout);
        }

        public Task<bool> PlaceOrder(string accessToken, string storeId, string cartVersion)
        {
            var path = $"/stores/{storeId}/orders";

            var body = new
            {
                CartVersion = cartVersion
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, WebApiClientConstants.ApplicationJson);

            return PostAsync<bool>(path, HttpMethod.Post, content, accessToken, null, HttpStatusSuccessCodes.CheckoutChange);
        }

        public Task<bool> RemoveCustomerPaymentCard(string accessToken, string storeId, string cardType, string cardNumber)
        {
            var path = $"/payments/{storeId}/customerCards/cards/{cardType}/{cardNumber}";
            return PostAsync<bool>(path, HttpMethod.Delete, null, accessToken, null, HttpStatusSuccessCodes.CheckoutDelete);
        }

        public Task<bool> SelectTimeSlot(string accessToken, string storeId, string reservationId)
        {
            var path = $"stores/{storeId}/slots/reserve";

            var body = new
            {
                ReservationId = reservationId
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, WebApiClientConstants.ApplicationJson);

            return PostAsync<bool>(path, HttpMethod.Post, content, accessToken, null, HttpStatusSuccessCodes.CheckoutChange);
        }
    }
}
