using DXP.SmartConnect.Ecom.SharedKernel;
using System;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CheckoutTimeSlot : BaseEntity<string>
    {
        public DateTime CutOff { set; get; }
        public string Date { set; get; }
        public DateTime EndDate { set; get; }
        public DateTime StartDate { set; get; }
        public string Price { set; get; }
        public string Time { set; get; }
        public string TimeSlotId { set; get; }
        public string TimeslotType { set; get; }
    }
}
