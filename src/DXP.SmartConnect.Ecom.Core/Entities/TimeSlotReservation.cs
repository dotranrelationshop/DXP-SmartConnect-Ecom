using DXP.SmartConnect.Ecom.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class TimeSlotReservation : BaseEntity<string>
    {
        public bool Confirmed { set; get; }
        public string ExpirationTime { set; get; }
        public string FulfilmentType { set; get; }
        public string ShoppingModeId { set; get; }
        public string SlotDateTimeLong { set; get; }
        public string SlotDateTimeShort { set; get; }
        public string StoreId { set; get; }
        public string UserId { set; get; }
        public string Price { set; get; }
    }
}
