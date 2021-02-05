using DXP.SmartConnect.Ecom.Core.Entities;
using System;
using System.Collections.Generic;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class CartItemDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string ProductVariantId { get; set; }
        public int Quantity { get; set; }
        public int? UserTemplateId { get; set; }
        public string ProductVariantName { get; set; }
        public string ArtWorkIds { get; set; }
        public ProductVariantDto ProductVariant { get; set; }
        public bool IsTemp { get; set; }
        public bool InStock { set; get; }
        public bool IsAvailable { set; get; }
        public bool? UseCustomService { get; set; }
        public string Message { get; set; }
        public bool? Substitution { get; set; }
        public decimal? ServicePrice { get; set; }
        public string CompanyId { get; set; }
        public string CustomizeName { get; set; }
        public int? RelativeItemId { get; set; }
        public string AddOns { get; set; }
        public double? Price { get; set; }
        public string PriceText { get; set; }
        public string StoreId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SaleInfo { get; set; }
        public double TotalPrice { get; set; }
        public IList<SizeDto> Sizes { get; set; }
        public string DefaultImage { get; set; }
        public string Brand { get; set; }
        public string UPC { get; set; }
        public string Size { set; get; }
        public bool? AllowSubstitutions { get; set; }
        public DateTime? PriceFromDate { get; set; }
        public DateTime? PriceToDate { get; set; }
        public decimal? UnitPrice { get; set; }
        public string DisplayUnitPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public string DisplaySalePrice { get; set; }
        public DateTime? SalePriceFromDate { get; set; }
        public DateTime? SalePriceToDate { get; set; }
        public decimal? SaleUnitPrice { get; set; }

        /// <summary>
        /// Transform object from type CartItem to type CartItemDto
        /// </summary>
        /// <returns>CartItemDto</returns>
        public static CartItemDto FromCartItem(CartItem item, string userId, string storeId)
        {
            var cartItem = new CartItemDto
            {
                Message = item.Note,
                Quantity = (int)item.QuantityValue,
                UserId = userId,
                UserName = userId,                 // User Name as User ID.
                StoreId = storeId,                 // External Store ID as Store retailer id.
                ProductVariantId = item.Sku,   // Variant ID as Product Id aka Sku.
                ProductVariantName = $"{item.Brand} {item.Name}",
                Id = item.Id,
                //CategoryId = item.CategoryId,
                CategoryName = item.Category,
                PriceText = item.TotalPrice,
                SaleInfo = item.TprInfo != null ? item.TprInfo.Label : "",
                TotalPrice = double.Parse(item.TotalPrice),
                DefaultImage = item.ImageUrl,
                IsAvailable = item.Available,
                ProductVariant = new ProductVariantDto
                {
                    Name = item.Name,
                    Price = double.Parse(item.TotalPrice),
                    //SalePrice = price,
                    ProductId = item.Sku,
                    Id = item.Sku,     // Variant ID as Product Id aka Sku.
                    Description = item.Description,
                    ProductName = item.Name,
                    //RetailPrice = (decimal)price,
                    Sku = item.Sku
                },
                Brand = item.Brand,
                UPC = item.Sku,
                AllowSubstitutions = item.AllowSubstitution
            };

            // Sizes.
            List<SizeDto> productSizes = new List<SizeDto>();
            if (item.UnitOfSize != null)
            {
                productSizes.Add(new SizeDto
                {
                    Size = item.UnitOfSize.Size.ToString(),
                    ItemKey = item.UnitOfSize.Label
                });
                cartItem.Sizes = productSizes;
            }
            // Ingredients (not existed Mi9v8).
            // InStock.
            string inStock = "";
            if (item.Attributes != null && item.Attributes.TryGetValue("Total On-Hand Qty", out inStock))
            {
                cartItem.InStock = int.Parse(inStock) > 0;
            }

            return cartItem;
        }
    }
}