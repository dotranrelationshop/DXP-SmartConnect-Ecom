using DXP.SmartConnect.Ecom.SharedKernel;
using System;
using System.Collections.Generic;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CartSummary : BaseEntity<string>
    {
        public int ItemCount { set; get; }
        public string SubTotal { set; get; }
        public string ServiceFee { set; get; }
        public string TaxTotal { set; get; }
        public IList<CartTax> TaxDetails { set; get; }
        public CartSaving Savings { set; get; }
        public CartSaving SavingsOnDelivery { set; get; }
        public string PointsEarned { set; get; }
        public string CustomerCredit { set; get; }
        public string Total { set; get; }
        public string OrderValue { set; get; }
    }
}