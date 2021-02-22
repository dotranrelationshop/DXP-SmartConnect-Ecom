using DXP.SmartConnect.Ecom.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class PaymentTokenization : BaseEntity<string>
    {
        public string Uri { get; set; }
        public string Method { get; set; }
        public bool Use3DSecure { get; set; }
        public IDictionary<string, string> Payload { get; set; }
    }
}
