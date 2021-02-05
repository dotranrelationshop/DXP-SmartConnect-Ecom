using DXP.SmartConnect.Ecom.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class CartReviewDto
    {
        public IList<CartMessageDto> Messages { get; set; }
        public CartSummaryDto Summary { get; set; } = new CartSummaryDto();
    }
}
