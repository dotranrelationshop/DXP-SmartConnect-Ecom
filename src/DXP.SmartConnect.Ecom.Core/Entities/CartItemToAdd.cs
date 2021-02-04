using System.Collections.Generic;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CartItemToAdd
    {
        public int Quantity { set; get; }
        public string Sku { set; get; }
        public string Note { set; get; }
        public bool AllowSubstitution { set; get; } = true;
        public CartItemSource Source { set; get; }
        public IDictionary<string, string> Attributes { set; get; }
    }
}