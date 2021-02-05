using DXP.SmartConnect.Ecom.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class CartDto
    {
        public string UserName { get; set; }
        public IList<CartItemDto> ShoppingCartItems { get; set; }
        public string StoreId { get; set; }
        public double TotalAmount { get; set; }
        public int TotalItem { get; set; }
        public int TotalQuantity { get; set; }


        /// <summary>
        /// Transform object from type Cart to type CartDto
        /// </summary>
        /// <returns>CartDto</returns>
        public static CartDto FromCart(Cart cart, string userId, string storeId)
        {
            var cartDto = new CartDto
            {
                ShoppingCartItems = new List<CartItemDto>(),
                StoreId = storeId,
                UserName = userId
            };

            if (cart != null && cart.LineItems != null && cart.LineItems.Any())
            {
                foreach (var item in cart.LineItems)
                {
                    cartDto.ShoppingCartItems.Add(CartItemDto.FromCartItem(item, userId, storeId));
                }

                cartDto.TotalAmount = double.Parse(cart.Summary.Total);
                cartDto.TotalItem = cart.LineItems != null ? cart.LineItems.Count : 0;
                cartDto.TotalQuantity = cart.Summary != null ? cart.Summary.ItemCount : 0;
            }

            return cartDto;
        }
    }
}
