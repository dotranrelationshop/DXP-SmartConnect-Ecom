using DXP.SmartConnect.Ecom.SharedKernel;
using System;
using System.Collections.Generic;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CartTax : BaseEntity<string>
    {
        public string GroupName { set; get; }
        public decimal Amount { set; get; }
    }
}