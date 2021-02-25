using DXP.SmartConnect.Ecom.SharedKernel;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class TimeSlot : BaseEntity<string>
    {
        public bool Available { set; get; }
        public string Price { set; get; }
        public string Range { set; get; }
        public string ReservationId { set; get; }
        public bool Selected { set; get; }
        public string SlotId { set; get; }
        public object Information { set; get; }
    }
}
