using DXP.SmartConnect.Ecom.Core.Entities;
using System;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class CheckoutTimeSlotDto
    {
        public DateTime CutOff { set; get; }
        public string Date { set; get; }
        public DateTime EndDate { set; get; }
        public DateTime StartDate { set; get; }
        public string Price { set; get; }
        public string Time { set; get; }
        public string TimeSlotId { set; get; }
        public string TimeslotType { set; get; }

        /// <summary>
        /// Transform object from type CheckoutTimeSlot to type CheckoutTimeSlotDto
        /// </summary>
        /// <returns>CheckoutTimeSlotDto</returns>
        public static CheckoutTimeSlotDto FromCheckoutTimeSlot(CheckoutTimeSlot item)
        {
            if (item != null)
            {
                return new CheckoutTimeSlotDto()
                {
                    CutOff = item.CutOff,
                    Date = item.Date,
                    EndDate = item.EndDate,
                    StartDate = item.StartDate,
                    Price = item.Price,
                    Time = item.Time,
                    TimeSlotId = item.TimeSlotId,
                    TimeslotType = item.TimeslotType
                };
            }
            return null;
        }
    }
}