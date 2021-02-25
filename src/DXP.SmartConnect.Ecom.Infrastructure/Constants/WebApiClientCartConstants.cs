namespace DXP.SmartConnect.Ecom.Infrastructure.Constants
{
    public static class WebApiClientCartConstants
    {
        public const string AddProductLineItemsToCart = "application/vnd.cart.v1+json;domain-model=AddProductLineItemsToCart";
        public const string AddProductLineItemToCart = "application/vnd.cart.v1+json;domain-model=AddProductLineItemToCart";
        public const string DeleteCart = "application/vnd.cart.v1+json;domain-model=DeleteCart";
        public const string RecordRewards = "application/vnd.cart.v1+json;domain-model=RecordRewards";
        public const string RemoveCartAttribute = "application/vnd.cart.v1+json;domain-model=RemoveCartAttribute";
        public const string RemoveLineItemAttribute = "application/vnd.cart.v1+json;domain-model=RemoveLineItemAttribute";
        public const string RemoveLineItemFromCart = "application/vnd.cart.v1+json;domain-model=RemoveLineItemFromCart";
        public const string ReplaceCart = "application/vnd.cart.v1+json;domain-model=ReplaceCart";
        public const string SetCartAttribute = "application/vnd.cart.v1+json;domain-model=SetCartAttribute";
        public const string SetLineItemAttribute = "application/vnd.cart.v1+json;domain-model=SetLineItemAttribute";
        public const string SetLineItemNote = "application/vnd.cart.v1+json;domain-model=SetLineItemNote";
        public const string SetLineItemQuantity = "application/vnd.cart.v1+json;domain-model=SetLineItemQuantity";
        public const string SetProductLineItemSubstitutionStatus = "application/vnd.cart.v1+json;domain-model=SetProductLineItemSubstitutionStatus";

        public const string DeleteCartReason = "empty cart";
        public const string DefaultCartSourceType = "catalog";
    }
}
