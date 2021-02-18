using DXP.SmartConnect.Ecom.Core.Entities;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class CustomerAddressDto
    {
        public string Country { set; get; }
        public string Line1 { set; get; }
        public string Line2 { set; get; }
        public string PostCode { set; get; }
        public string Region { set; get; }
        public string Source { set; get; }
        public string TownCity { set; get; }

        /// <summary>
        /// Transform object from type CustomerAddress to type CustomerAddressDto
        /// </summary>
        /// <returns>CustomerAddressDto</returns>
        public static CustomerAddressDto FromCustomerAddress(CustomerAddress item)
        {
            if (item != null)
            {
                return new CustomerAddressDto()
                {
                    Country = item.Country,
                    Line1 = item.Line1,
                    Line2 = item.Line2,
                    PostCode = item.PostCode,
                    Region = item.Region,
                    Source = item.Source,
                    TownCity = item.TownCity
                };
            }
            return null;
        }
    }
}