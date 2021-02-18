using DXP.SmartConnect.Ecom.Core.Entities;
using DXP.SmartConnect.Ecom.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class PaymentCustomerCardDto
    {
        public string CardholderName { get; set; }
        public string CreditCardToken { get; set; }
        public string MaskedCardNumber { get; set; }
        public string CardType { get; set; }
        public string CardExpiration { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsExpired { get; set; }
        public bool AvsMatch { get; set; }

        /// <summary>
        /// Transform object from type PaymentCustomerCard to type PaymentCustomerCardDto
        /// </summary>
        /// <returns>PaymentCustomerCardDto</returns>
        public static PaymentCustomerCardDto FromPaymentCustomerCard(PaymentCustomerCard item)
        {
            if (item != null)
            {
                return new PaymentCustomerCardDto
                {
                    CardholderName = item.CardholderName,
                    CreditCardToken = item.CreditCardToken,
                    MaskedCardNumber = item.MaskedCardNumber,
                    CardType = item.CardType,
                    CardExpiration = item.CardExpiration,
                    IsPrimary = item.IsPrimary,
                    IsExpired = item.IsExpired,
                    AvsMatch = item.AvsMatch
                };
            }
            return null;
        }
    }
}
