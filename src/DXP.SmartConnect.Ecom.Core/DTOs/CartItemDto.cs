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
        public IList<SizesDto> Sizes { get; set; }
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
    }
}