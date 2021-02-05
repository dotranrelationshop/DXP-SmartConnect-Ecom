using DXP.SmartConnect.Ecom.Core.DTOs;
using DXP.SmartConnect.Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        /// <summary>
        /// Get shopping cart review by username, storeId
        /// </summary>
        /// <param name="userName">Username or userIdd</param>
        /// <param name="storeId">Store Number</param>
        /// <returns></returns>
        // GET: ​api/shoppingcart/review
        [HttpGet("review")]
        public async Task<CartReviewDto> GetCartReview(string userName, string storeId)
        {
            return await _cartService.GetCartReview(userName, storeId);
        }

        /// <summary>
        /// Add an item to user shopping cart
        /// </summary>
        /// <param name="shoppingCartItem"></param>
        /// <returns></returns>
        // POST: ​api/shoppingcart/add-item
        [HttpPost("add-item")]
        public async Task<CartItemDto> AddCartItem(CartItemDto shoppingCartItem)
        {
            return await _cartService.AddCartItem(shoppingCartItem);
        }

        /// <summary>
        /// Add List Items to User Shopping Cart
        /// </summary>
        /// <param name="cartItems"></param>
        /// <returns></returns>
        // POST: ​api/shoppingcart/add-items
        [HttpPost("add-items")]
        public async Task<bool> AddCartItems(IList<CartItemDto> cartItems)
        {
            return await _cartService.AddCartItems(cartItems);
        }

        /// <summary>
        /// Update an item from user shopping cart
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        // POST: ​api/shoppingcart/update-item
        [HttpPost("update-item")]
        public async Task<CartDto> UpdateCartItem(CartItemDto cartItem)
        {
            return await _cartService.UpdateCartItem(cartItem);
        }

        /// <summary>
        /// Delete item from shopping cart
        /// </summary>
        /// <param name="cardItemId">Shopping cart item ID</param>
        /// <param name="userId">userId</param>
        /// <param name="storeId">Store Number</param>
        /// <returns></returns>
        // DELETE: ​api/shoppingcart/delete-item
        [HttpDelete("delete-item")]
        public async Task<CartDto> DeleteCartItem(string userId, string storeId, string cardItemId)
        {
            return await _cartService.DeleteCartItem(userId, storeId, cardItemId);

        }

        /// <summary>
        /// Delete all item from shopping cart of user
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="storeId">storeId</param>
        /// <returns></returns>
        // DELETE: ​api/shoppingcart/delete-all
        [HttpDelete("delete-all")]
        public async Task<bool> DeleteAllShoppingCartItem(string userId, string storeId)
        {
            return await _cartService.DeleteCart(userId, storeId);
        }
    }
}
