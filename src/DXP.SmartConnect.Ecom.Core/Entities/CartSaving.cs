using DXP.SmartConnect.Ecom.SharedKernel;
using System;
using System.Collections.Generic;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CartSaving : BaseEntity<string>
    {
        public string NotPromoCodeSavings { set; get; }
        public IList<CartPromoCode> PromoCodesSavings { set; get; }
        public string TotalSavings { set; get; }
    }
}