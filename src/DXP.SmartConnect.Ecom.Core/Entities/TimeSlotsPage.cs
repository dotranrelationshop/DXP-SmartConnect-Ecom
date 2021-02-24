using DXP.SmartConnect.Ecom.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class TimeSlotsPage : BaseEntity<string>
    {
        public IList<TimeSlotsDay> Days { set; get; }
        public int CurrentPage { set; get; }
        public int PageLimit { set; get; }
        public string RetailerStoreId { set; get; }
        public string ShoppingModeId { set; get; }
    }
}
