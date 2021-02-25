using DXP.SmartConnect.Ecom.SharedKernel;
using System.Collections.Generic;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CartItem : BaseEntity<string>
    {
        public string Sku { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Brand { set; get; }
        public string Category { set; get; }
        public string TotalPrice { set; get; }
        public string TotalPriceWithPromotions { set; get; }
        public string LineItemPrice { set; get; }
        public string UnitPrice { set; get; }
        public double QuantityValue { set; get; }
        public ProductUnit UnitOfSize { set; get; }
        public ProductUnit UnitOfMeasure { set; get; }
        public ProductUnit UnitOfPrice { set; get; }
        public string QuantityType { set; get; }
        public string Note { set; get; }
        public bool AllowSubstitution { set; get; }
        public IDictionary<string, string> Image { set; get; }
        public string ImageUrl { set; get; }
        public IDictionary<string, string> Attributes { set; get; }
        public CartPromotion Promotions { set; get; }
        public bool Available { set; get; }
        public bool UnitsMissMatch { set; get; }
        public string SellBy { set; get; }
        public IList<CartReward> Rewards { set; get; }
        public CartTprInfo TprInfo { set; get; }
    }
}