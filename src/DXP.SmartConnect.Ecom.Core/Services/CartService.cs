using DXP.SmartConnect.Ecom.Core.DTOs;
using DXP.SmartConnect.Ecom.Core.Interfaces;
using DXP.SmartConnect.Ecom.Core.Settings;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Core.Services
{
    public class CartService : ICartService
    {
        private readonly ICartWebApiClient _cartWebApiClient;
        private readonly ApplicationSettings _setting;

        public CartService(ICartWebApiClient cartWebApiClient, IOptions<ApplicationSettings> options)
        {
            _cartWebApiClient = cartWebApiClient;
            _setting = options.Value;
        }

        public async Task<CartDto> GetCart(string userName, string storeId)
        {
            var cart = await _cartWebApiClient.GetCartByStore(_setting.AccessToken, storeId);

            return CartDto.FromCart(cart);
        }
    }
}
