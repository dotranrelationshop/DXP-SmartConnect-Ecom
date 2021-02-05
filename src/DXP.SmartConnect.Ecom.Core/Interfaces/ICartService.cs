using DXP.SmartConnect.Ecom.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Core.Interfaces
{
    public interface ICartService
    {
        /// <summary>
        /// Get the cart detail of user.
        /// </summary>
        /// <param name="userName">The owner's id or username of the cart </param>
        /// <param name="storeId">The store id </param>
        /// <returns>The cart detail</returns>
        Task<CartDto> GetCart(string userName, string storeId);
        /// <summary>
        /// Get the cart review of user.
        /// </summary>
        /// <param name="userName">The owner's id or username of the cart </param>
        /// <param name="storeId">The store id </param>
        /// <returns>The cart review</returns>
        Task<CartReviewDto> GetCartReview(string userName, string storeId);
        /// <summary>
        /// Add product to cart.
        /// </summary>
        /// <param name="cartItem">The cart item detail </param>
        /// <returns>The cart item detail</returns>
        Task<CartItemDto> AddCartItem(CartItemDto cartItem);
        /// <summary>
        /// Add list product to cart.
        /// </summary>
        /// <param name="cartItems">List cart items </param>
        /// <returns>The status of command</returns>
        Task<bool> AddCartItems(IList<CartItemDto> cartItems);
        /// <summary>
        /// Update the cart item (quantity, note, substitution).
        /// </summary>
        /// <param name="cartItem">The cart item detail </param>
        /// <returns>The cart detail</returns>
        Task<CartDto> UpdateCartItem(CartItemDto cartItem);
        /// <summary>
        /// Delete product from cart.
        /// </summary>
        /// <param name="userId">The owner's id of the cart </param>
        /// <param name="storeId">The store id </param>
        /// <param name="cartItemId">The cart item id </param>
        /// <returns>The cart after delete item</returns>
        Task<CartDto> DeleteCartItem(string userId, string storeId, string cartItemId);
        /// <summary>
        /// Delete all product from cart.
        /// </summary>
        /// <param name="userId">The owner's id of the cart </param>
        /// <param name="storeId">The store id </param>
        /// <returns>Status of command</returns>
        Task<bool> DeleteCart(string userId, string storeId);
        /// <summary>
        ///  Update substitution for all cart item.
        /// </summary>
        /// <param name="userId">The owner's id of the cart </param>
        /// <param name="storeId">The store id </param>
        /// <param name="isUpdate">Status of substitution </param>
        /// <returns>Status of command</returns>
        Task<bool> UpdateAllItemSubstitution(string userId, string storeId, bool isUpdate);
    }
}
