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
    public class CartService : BaseService, ICartService
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

            if (cart != null && cart.LineItems != null && cart.LineItems.Any())
            {
                foreach (var item in cart.LineItems)
                {
                    item.TotalPrice = RemoveSpecialChars(item.TotalPrice);
                    item.ImageUrl = $"{_setting.CloudContentUrl}/DefaultMissingImage.jpg";
                    if (item.Image.TryGetValue(_setting.ProductImageDimensions, out string imageUrl))
                    {
                        item.ImageUrl = imageUrl;
                    }
                }

                var total = RemoveSpecialChars(cart.Summary?.Total);
                cart.Summary.Total = total ?? "0";
            }

            return CartDto.FromCart(cart, userName, storeId);
        }

        public async Task<CartReviewDto> GetCartReview(string userName, string storeId)
        {
            var cart = await _cartWebApiClient.GetCartByStore(_setting.AccessToken, storeId);

            if (cart != null)
            {
                var itemCount = cart.LineItems?.Count;

                return new CartReviewDto
                {
                    Summary = CartSummaryDto.FromCartSummary(cart.Summary, itemCount)
                };
            }

            return null;
        }

        public async Task<CartItemDto> AddCartItem(CartItemDto cartItem)
        {
            if (cartItem != null && !string.IsNullOrEmpty(cartItem.ProductVariantId))
            {
                var productToAdd = new CartItemToAdd
                {
                    Sku = cartItem.ProductVariantId,
                    Quantity = cartItem.Quantity,
                    Note = cartItem.Message,
                    AllowSubstitution = cartItem.AllowSubstitutions ?? false
                };
                var addedResult = await _cartWebApiClient.AddItemToCart(_setting.AccessToken, cartItem.StoreId, productToAdd);

                if (addedResult)
                {
                    return cartItem;
                }
            }
            return null;
        }

        public async Task<bool> AddCartItems(IList<CartItemDto> cartItems)
        {
            if (cartItems == null || !cartItems.Any())
                return false;

            var listProductToAdd = new List<CartItemToAdd>();
            var storeId = "";

            foreach (var item in cartItems)
            {
                if (item != null && !string.IsNullOrEmpty(item.ProductVariantId))
                {
                    storeId = item.StoreId ?? "";
                    var productToAdd = new CartItemToAdd
                    {
                        Sku = item.ProductVariantId,
                        Quantity = item.Quantity,
                        Note = item.Message,
                        AllowSubstitution = item.AllowSubstitutions ?? false
                    };
                    listProductToAdd.Add(productToAdd);
                }
            }

            return  await _cartWebApiClient.AddItemsToCart(_setting.AccessToken, storeId, listProductToAdd);
        }

        public async Task<CartDto> UpdateCartItem(CartItemDto cartItem)
        {
            var userId = cartItem.UserId;
            var storeId = cartItem.StoreId;
            var itemId = cartItem.Id;

            // Update Cart item quantity.
            var quantity = cartItem.Quantity;
            await _cartWebApiClient.UpdateItemQuantity(_setting.AccessToken, storeId, itemId, quantity);

            // Update Cart item note.
            var note = cartItem.Message;
            await _cartWebApiClient.UpdateItemNote(_setting.AccessToken, storeId, itemId, note);

            // Update Cart item substitution.
            var substitution = cartItem.AllowSubstitutions ?? false;
            await _cartWebApiClient.UpdateItemSubstitution(_setting.AccessToken, storeId, itemId, substitution);

            // Get cart after update to take latest data.
            return await GetCart(userId, storeId);
        }

        public async Task<CartDto> DeleteCartItem(string userId, string storeId, string cartItemId)
        {
            await _cartWebApiClient.DeleteItemFromCart(_setting.AccessToken, storeId, cartItemId);

            return await GetCart(userId, storeId);
        }

        public async Task<bool> DeleteCart(string userId, string storeId)
        {
            return await _cartWebApiClient.DeleteCart(_setting.AccessToken, storeId);
        }

        public Task<bool> UpdateAllItemSubstitution(string userId, string storeId, bool isUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}
