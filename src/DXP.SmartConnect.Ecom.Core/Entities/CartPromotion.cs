using DXP.SmartConnect.Ecom.SharedKernel;
using System.Collections.Generic;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CartPromotion : BaseEntity<string>
    {
        public IList<CartPromotionRetailer> Redeemed { set; get; }
        public IList<CartPromotionRetailer> Missed { set; get; }
    }
}