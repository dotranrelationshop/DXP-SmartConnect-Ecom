using DXP.SmartConnect.Ecom.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CheckoutFulfilment : BaseEntity<string>
    {
        public CheckoutTimeSlot Timeslot { set; get; }
        public string TimeslotReservationReference { set; get; }
        public string Name { set; get; }
        public string FulfilmentType { set; get; }
        public object Promotions { set; get; }
    }
}
