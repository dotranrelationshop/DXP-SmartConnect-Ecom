using DXP.SmartConnect.Ecom.Core.Entities;
using DXP.SmartConnect.Ecom.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class TimeSlotReservationDto
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

        /// <summary>
        /// Transform object from type TimeSlotReservation to type TimeSlotReservationDto
        /// </summary>
        /// <returns>TimeSlotReservationDto</returns>
        public static TimeSlotReservationDto FromTimeSlotReservation(TimeSlotReservation item)
        {
            if (item != null)
            {
                return new TimeSlotReservationDto
                {
                    Confirmed = item.Confirmed,
                    ExpirationTime = item.ExpirationTime,
                    FulfilmentType = item.FulfilmentType,
                    ShoppingModeId = item.ShoppingModeId,
                    SlotDateTimeLong = item.SlotDateTimeLong,
                    SlotDateTimeShort = item.SlotDateTimeShort,
                    StoreId = item.StoreId,
                    UserId = item.UserId,
                    Price = item.Price
                };
            }
            return null;
        }
    }
}
