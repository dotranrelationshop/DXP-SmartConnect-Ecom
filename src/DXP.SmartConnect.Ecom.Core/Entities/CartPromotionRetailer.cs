using DXP.SmartConnect.Ecom.SharedKernel;
using System;
using System.Collections.Generic;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CartPromotionRetailer : BaseEntity<string>
    {
        public string PromotionRetailerId { set; get; }
        public string Description { set; get; }
        public string AdditionalInformation { set; get; }
        public decimal Amount { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public int Limit { set; get; }
        public int Threshold { set; get; }
        public int MinimumQuantity { set; get; }
        public bool PointsBased { set; get; }
        public string CompensatingAction { set; get; }
        public IList<string> MissingSkus { set; get; }
        public int TargetSkuCount { set; get; }
        public int MissingSkuCount { set; get; }
        public int SpendRequired { set; get; }
        public int TargetSpend { set; get; }
        public int PercentageOfCompletion { set; get; }
    }
}