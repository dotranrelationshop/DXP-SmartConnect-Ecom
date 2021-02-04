using DXP.SmartConnect.Ecom.Core.DTOs;
using DXP.SmartConnect.Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.API.Controllers
{
    [Route("/api/shoppingcart")]
    public class CartController : BaseApiController
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        /// <summary>
        /// Get shopping cart by username, storeId
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="storeId">Store Number</param>
        /// <returns>shopping cart detail</returns>
        // GET: ​api/shoppingcart/user
        [HttpGet("user")]
        public async Task<CartDto> GetCart(string userName, string storeId)
        {
            var cart = await _cartService.GetCart(userName, storeId);
            return cart;
        }
    }
}
