using DXP.SmartConnect.Ecom.Core.Entities;
using DXP.SmartConnect.Ecom.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class TimeSlotsPageDto
    {
        public IList<TimeSlotsDayDto> Days { set; get; }
        public int CurrentPage { set; get; }
        public object PageLimit { set; get; }
        public string RetailerStoreId { set; get; }
        public string ShoppingModeId { set; get; }

        /// <summary>
        /// Transform object from type TimeSlotsPage to type TimeSlotsPageDto
        /// </summary>
        /// <returns>TimeSlotsPageDto</returns>
        public static TimeSlotsPageDto FromTimeSlotsPage(TimeSlotsPage item)
        {
            if (item != null)
            {
                var slotsPage = new TimeSlotsPageDto
                {
                    CurrentPage = item.CurrentPage,
                    PageLimit = item.PageLimit,
                    RetailerStoreId = item.RetailerStoreId,
                    ShoppingModeId = item.ShoppingModeId,
                    Days = new List<TimeSlotsDayDto>()
                };

                if (item.Days?.Any() ?? false)
                {
                    foreach(var day in item.Days)
                    {
                        slotsPage.Days.Add(TimeSlotsDayDto.FromTimeSlotsDay(day));
                    }
                }

                return slotsPage;
            }
            return null;
        }
    }
}
