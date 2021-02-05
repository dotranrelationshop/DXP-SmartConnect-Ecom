using DXP.SmartConnect.Ecom.Core.Entities;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class CartSummaryDto
    {
        public string ListId { get; set; }
        public string ListName { get; set; }
        public string TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
        public int ItemCount { get; set; }

        /// <summary>
        /// Transform object from type CartSummary to type CartSummaryDto
        /// </summary>
        /// <returns>CartSummaryDto</returns>
        public static CartSummaryDto FromCartSummary(CartSummary item, int? itemCount)
        {
            var cartSummary = new CartSummaryDto();
            if (item != null)
            {
                cartSummary.TotalPrice = item.Total;
                cartSummary.TotalQuantity = item.ItemCount;
                cartSummary.ItemCount = itemCount ?? 0;
            }

            return cartSummary;
        }
    }
}