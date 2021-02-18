using DXP.SmartConnect.Ecom.SharedKernel;
using System.Collections.Generic;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class TimeSlotsDay : BaseEntity<string>
    {
        public string Label { set; get; }
        public string SubLabel { set; get; }
        public IList<TimeSlot> Slots { set; get; }
    }
}