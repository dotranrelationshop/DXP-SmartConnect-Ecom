using DXP.SmartConnect.Ecom.Core.Entities;
using DXP.SmartConnect.Ecom.Core.Interfaces;
using DXP.SmartConnect.Ecom.Infrastructure.Constants;
using DXP.SmartConnect.Ecom.SharedKernel.WebApi;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Infrastructure.Data.WebApiClients
{
    public class CartWebApiClient : WebApiClient, ICartWebApiClient
    {
        private readonly ILogger<ProductWebApiClient> _logger;

        public CartWebApiClient(ILogger<ProductWebApiClient> logger, HttpClient client) : base(logger, client)
        {
            _logger = logger;
        }

        public Task<bool> AddItemToCart(string accessToken, string storeId, CartItemToAdd item)
        {
            var path = $"stores/{storeId}/cart";

            var header = new Dictionary<string, string>();
            header.Add(WebApiClientConstants.HeaderContentType, WebApiClientCartConstants.AddProductLineItemToCart);
            item.Source = new CartItemSource // Required parameter.
            {
                Type = WebApiClientCartConstants.DefaultCartSourceType
            };
            var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, WebApiClientConstants.ApplicationJson);

            return PostAsync<bool>(path, HttpMethod.Post, content, accessToken, header, HttpStatusSuccessCodes.CartChange);
        }

        public Task<bool> AddItemsToCart(string accessToken, string storeId, IList<CartItemToAdd> items)
        {
            var path = $"stores/{storeId}/cart";

            var header = new Dictionary<string, string>();
            header.Add(WebApiClientConstants.HeaderContentType, WebApiClientCartConstants.AddProductLineItemsToCart);
            var body = new
            {
                LineItems = items,
                Source = new CartItemSource // Required parameter.
                {
                    Type = WebApiClientCartConstants.DefaultCartSourceType
                }
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, WebApiClientConstants.ApplicationJson);

            return PostAsync<bool>(path, HttpMethod.Post, content, accessToken, header, HttpStatusSuccessCodes.CartChange);
        }

        public Task<bool> DeleteCart(string accessToken, string storeId)
        {
            var path = $"stores/{storeId}/cart";

            var header = new Dictionary<string, string>();
            header.Add(WebApiClientConstants.HeaderContentType, WebApiClientCartConstants.DeleteCart);
            var body = new
            {
                Reason = WebApiClientCartConstants.DeleteCartReason
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, WebApiClientConstants.ApplicationJson);

            return PostAsync<bool>(path, HttpMethod.Post, content, accessToken, header, HttpStatusSuccessCodes.CartChange);
        }

        public Task<bool> DeleteItemFromCart(string accessToken, string storeId, string itemId)
        {
            var path = $"stores/{storeId}/cart";

            var header = new Dictionary<string, string>();
            header.Add(WebApiClientConstants.HeaderContentType, WebApiClientCartConstants.RemoveLineItemFromCart);
            var body = new
            {
                LineItemId = itemId
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, WebApiClientConstants.ApplicationJson);

            return PostAsync<bool>(path, HttpMethod.Post, content, accessToken, header, HttpStatusSuccessCodes.CartChange);
        }

        public Task<Cart> GetCartByStore(string accessToken, string storeId)
        {
            var path = $"stores/{storeId}/cart";
            return GetAsync<Cart>(path, accessToken, null, HttpStatusSuccessCodes.GetCart);
        }

        public Task<bool> UpdateItemNote(string accessToken, string storeId, string itemId, string note)
        {
            var path = $"stores/{storeId}/cart";

            var header = new Dictionary<string, string>();
            header.Add(WebApiClientConstants.HeaderContentType, WebApiClientCartConstants.SetLineItemNote);
            var body = new
            {
                LineItemId = itemId,
                Note = note
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, WebApiClientConstants.ApplicationJson);

            return PostAsync<bool>(path, HttpMethod.Post, content, accessToken, header, HttpStatusSuccessCodes.CartChange);
        }

        public Task<bool> UpdateItemQuantity(string accessToken, string storeId, string itemId, int quantity)
        {
            var path = $"stores/{storeId}/cart";

            var header = new Dictionary<string, string>();
            header.Add(WebApiClientConstants.HeaderContentType, WebApiClientCartConstants.SetLineItemQuantity);
            var body = new
            {
                LineItemId = itemId,
                Quantity = quantity
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, WebApiClientConstants.ApplicationJson);

            return PostAsync<bool>(path, HttpMethod.Post, content, accessToken, header, HttpStatusSuccessCodes.CartChange);
        }

        public Task<bool> UpdateItemSubstitution(string accessToken, string storeId, string itemId, bool substitutionStatus)
        {
            var path = $"stores/{storeId}/cart";

            var header = new Dictionary<string, string>();
            header.Add(WebApiClientConstants.HeaderContentType, WebApiClientCartConstants.SetProductLineItemSubstitutionStatus);
            var body = new
            {
                LineItemId = itemId,
                Status = substitutionStatus
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, WebApiClientConstants.ApplicationJson);

            return PostAsync<bool>(path, HttpMethod.Post, content, accessToken, header, HttpStatusSuccessCodes.CartChange);
        }
    }
}
