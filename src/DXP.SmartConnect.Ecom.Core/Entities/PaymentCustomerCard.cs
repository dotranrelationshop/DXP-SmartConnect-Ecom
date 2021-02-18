using DXP.SmartConnect.Ecom.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class PaymentCustomerCard : BaseEntity<string>
    {
        public string CardholderName { get; set; }
        public string CreditCardToken { get; set; }
        public string MaskedCardNumber { get; set; }
        public string CardType { get; set; }
        public string CardExpiration { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsExpired { get; set; }
        public bool AvsMatch { get; set; }
    }
}
