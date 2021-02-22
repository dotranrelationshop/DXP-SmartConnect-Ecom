using DXP.SmartConnect.Ecom.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class Payment : BaseEntity<string>
    {
        public decimal FinalAmount { get; set; }
        public bool IsMobile { get; set; }
        public string SuccessCallbackUri { get; set; }
        public string CancelCallbackUri { get; set; }
        public PaymentAddress PaymentAddress { get; set; }
        public IDictionary<string, string> HostedPayPageUrlParameters { get; set; }
    }
}
