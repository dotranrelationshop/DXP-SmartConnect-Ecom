using DXP.SmartConnect.Ecom.Core.Entities;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class TimeSlotDto
    {
        public bool Available { set; get; }
        public string Price { set; get; }
        public string Range { set; get; }
        public string ReservationId { set; get; }
        public bool Selected { set; get; }
        public string SlotId { set; get; }
        public object Information { set; get; }

        /// <summary>
        /// Transform object from type TimeSlot to type TimeSlotDto
        /// </summary>
        /// <returns>TimeSlotDto</returns>
        public static TimeSlotDto FromTimeSlot(TimeSlot item)
        {
            if (item != null)
            {
                return new TimeSlotDto
                {
                    Available = item.Available,
                    Price = item.Price,
                    Range = item.Range,
                    ReservationId = item.ReservationId,
                    Selected = item.Selected,
                    SlotId = item.SlotId,
                    Information = item.Information
                };
            }
            return null;
        }
    }
}
