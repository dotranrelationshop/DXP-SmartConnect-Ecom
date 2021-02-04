using DXP.SmartConnect.Ecom.SharedKernel;
using System;
using System.Collections.Generic;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class Cart : BaseEntity<string>
    {
        public CartSummary Summary { set; get; }
        public CartPromotion Promotions { set; get; }
        public IList<CartItem> LineItems { set; get; }
        public string Version { set; get; }
        public DateTime ModifiedOn { set; get; }
    }
}