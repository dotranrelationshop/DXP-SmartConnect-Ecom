using DXP.SmartConnect.Ecom.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class CartDto
    {
        public string UserName { get; set; }

        public IList<CartItemDto> ShoppingCartItems { get; set; }

        // util funtion
        public IList<CartItemDto> GetSubItems(int cartitemId)
        {
            if (this.ShoppingCartItems == null)
            {
                return null;
            }
            return this.ShoppingCartItems.Where(i => i.RelativeItemId == cartitemId).ToList();
        }

        public string StoreId { get; set; }
        public double TotalAmount { get; set; }
        public int TotalItem { get; set; }
        public int TotalQuantity { get; set; }


        // function
        public static CartDto FromCart(Cart item)
        {
            if (item != null)
            {
                return new CartDto()
                {
                };
            }
            return null;
        }
    }
}
