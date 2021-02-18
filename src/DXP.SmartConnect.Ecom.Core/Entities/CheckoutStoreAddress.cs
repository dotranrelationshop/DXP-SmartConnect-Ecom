using DXP.SmartConnect.Ecom.SharedKernel;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CheckoutStoreAddress : BaseEntity<string>
    {
        public string Line1 { set; get; }
        public string Line2 { set; get; }
        public string Line3 { set; get; }
        public string CountyProvinceState { set; get; }
        public string Country { set; get; }
        public string PostCode { set; get; }
        public string City { set; get; }
    }
}