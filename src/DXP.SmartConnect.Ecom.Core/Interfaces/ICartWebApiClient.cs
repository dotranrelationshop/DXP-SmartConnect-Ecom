using DXP.SmartConnect.Ecom.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Core.Interfaces
{
    public interface ICartWebApiClient
    {
        /// <summary>
        /// Get user shopping cart for a given store.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <returns>Cart detail</returns>
        Task<Cart> GetCartByStore(string accessToken, string storeId);
        /// <summary>
        /// Add product item to shopping cart.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="item">The item info to add </param>
        /// <returns>Status of request</returns>
        Task<bool> AddItemToCart(string accessToken, string storeId, CartItemToAdd item);
        /// <summary>
        /// Add list product items to shopping cart.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="items">List items info to add </param>
        /// <returns>Status of request</returns>
        Task<bool> AddItemsToCart(string accessToken, string storeId, IList<CartItemToAdd> items);
        /// <summary>
        /// Update product item quantity in shopping cart.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="itemId">The item id in cart </param>
        /// <param name="quantity">The quantity of item </param>
        /// <returns>Status of request</returns>
        Task<bool> UpdateItemQuantity(string accessToken, string storeId, string itemId, int quantity);
        /// <summary>
        /// Update product item note in shopping cart.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="itemId">The item id in cart </param>
        /// <param name="note">The note of item </param>
        /// <returns>Status of request</returns>
        Task<bool> UpdateItemNote(string accessToken, string storeId, string itemId, string note);
        /// <summary>
        /// Update product item substitution status in shopping cart.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="itemId">The item id in cart </param>
        /// <param name="substitutionStatus">Status of item substitution</param>
        /// <returns>Status of request</returns>
        Task<bool> UpdateItemSubstitution(string accessToken, string storeId, string itemId, bool substitutionStatus);
        /// <summary>
        /// Delete product item from shopping cart.
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <param name="itemId">The item id in cart </param>
        /// <returns>Status of request</returns>
        Task<bool> DeleteItemFromCart(string accessToken, string storeId, string itemId);
        /// <summary>
        /// Delete shopping cart (Delete all items from shopping cart).
        /// </summary>
        /// <param name="storeId">Retailer Store Id </param>
        /// <returns>Status of request</returns>
        Task<bool> DeleteCart(string accessToken, string storeId);
    }
}
