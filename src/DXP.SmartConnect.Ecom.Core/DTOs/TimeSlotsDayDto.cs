using DXP.SmartConnect.Ecom.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class TimeSlotsDayDto
    {
        public string Label { set; get; }
        public string SubLabel { set; get; }
        public IList<TimeSlotDto> Slots { set; get; }

        /// <summary>
        /// Transform object from type TimeSlotsDay to type TimeSlotsDayDto
        /// </summary>
        /// <returns>TimeSlotsDayDto</returns>
        public static TimeSlotsDayDto FromTimeSlotsDay(TimeSlotsDay item)
        {
            if (item != null)
            {
                var slotsDay = new TimeSlotsDayDto
                {
                    Label = item.Label,
                    SubLabel = item.SubLabel,
                    Slots = new List<TimeSlotDto>()
                };

                if (item.Slots?.Any() ?? false)
                {
                    foreach (var slot in item.Slots)
                    {
                        slotsDay.Slots.Add(TimeSlotDto.FromTimeSlot(slot));
                    }
                }

                return slotsDay;
            }
            return null;
        }
    }
}