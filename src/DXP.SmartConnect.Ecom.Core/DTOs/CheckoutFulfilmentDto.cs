using DXP.SmartConnect.Ecom.Core.Entities;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class CheckoutFulfilmentDto
    {
        public CheckoutTimeSlotDto Timeslot { set; get; }
        public string TimeslotReservationReference { set; get; }
        public string Name { set; get; }
        public string FulfilmentType { set; get; }
        public object Promotions { set; get; }

        /// <summary>
        /// Transform object from type CheckoutFulfilment to type CheckoutFulfilmentDto
        /// </summary>
        /// <returns>CheckoutFulfilmentDto</returns>
        public static CheckoutFulfilmentDto FromCheckoutFulfilment(CheckoutFulfilment item)
        {
            if (item != null)
            {
                return new CheckoutFulfilmentDto()
                {
                    TimeslotReservationReference = item.TimeslotReservationReference,
                    Name = item.Name,
                    FulfilmentType = item.FulfilmentType,
                    Promotions = item.Promotions,
                    Timeslot = CheckoutTimeSlotDto.FromCheckoutTimeSlot(item.Timeslot)
                };
            }
            return null;
        }
    }
}