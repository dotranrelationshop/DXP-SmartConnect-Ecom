﻿using DXP.SmartConnect.Ecom.Core.Entities;
using System;
using System.Collections.Generic;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class ProductDTO
    {
        public string Id { get; set; }
        public String Name { get; set; }
        public String ShortDescription { get; set; }
        public String FullDescription { get; set; }
        public string CompanyId { get; set; }
        public string ProductType { get; set; }
        public double Price { get; set; }
        public bool? ShowMainPrice { get; set; }
        public decimal? CostPrice { get; set; }
        public double? SalePrice { get; set; }
        public string SalePriceText { get; set; }
        public bool? ShowSalePrice { get; set; }
        public string TaxClass { get; set; }
        public bool AvailableInAllStore { get; set; }
        public bool AvailableInStore { get; set; }
        public bool Available { get; set; }
        public bool InStock { get; set; }
        public string DefaultImage { get; set; }
        public string WarrantyInfo { get; set; }
        public string Tags { get; set; }
        public string Condition { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string UPC { get; set; }
        public Nullable<int> MinPurchaseQuantity { get; set; }
        public Nullable<int> MaxPurchaseQuantity { get; set; }
        public string ValueType { get; set; }
        public string ItemSize { get; set; }
        public bool OnSale { get; set; }
        public string InventoryTracking { get; set; }
        public Nullable<int> CurrentStock { get; set; }
        public Nullable<int> LowStock { get; set; }
        public string Information { get; set; }
        public ICollection<ProductVariantDTO> ProductVariants { get; set; }
        public ICollection<ProductAtributeDTO> ProductAttributes { get; set; }
        public ICollection<ProductCategoryDTO> ProductCategories { get; set; }
        public string PriceText { get; set; }
        public string SaleInfo { get; set; }
        public string Category { get; set; }
        public string ExternalId { get; set; }
        public List<SizesDTO> Sizes { set; get; }
        public string ItemKey { set; get; }
        public string UnitPrice { set; get; }
        public PointRedemptionDTO PointRedemptionInfo { get; set; }
        public string Disclaimer { set; get; }
        public string Ingredients { set; get; }

        public static ProductDTO FromProduct(Product item)
        {
            if (item != null)
            {
                return new ProductDTO()
                {
                    Id = item.Sku,
                    Name = item.Name
                };
            }
            return null;
        }
    }
}