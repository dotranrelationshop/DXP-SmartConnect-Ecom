using DXP.SmartConnect.Ecom.Core.Entities;

namespace DXP.SmartConnect.Ecom.Core.DTOs
{
    public class CheckoutStoreDto
    {
        public string Name { set; get; }
        public string AddressLine1 { set; get; }
        public string AddressLine2 { set; get; }
        public string AddressLine3 { set; get; }
        public string CountyProvinceState { set; get; }
        public string Country { set; get; }
        public string PostCode { set; get; }
        public string City { set; get; }

        /// <summary>
        /// Transform object from type CheckoutStore to type CheckoutStoreDto
        /// </summary>
        /// <returns>CheckoutStoreDto</returns>
        public static CheckoutStoreDto FromCheckoutStore(CheckoutStore item)
        {
            if (item != null)
            {
                return new CheckoutStoreDto()
                {
                    Name = item.Name,
                    AddressLine1 = item.Address?.Line1,
                    AddressLine2 = item.Address?.Line2,
                    AddressLine3 = item.Address?.Line3,
                    CountyProvinceState = item.Address?.CountyProvinceState,
                    Country = item.Address?.Country,
                    PostCode = item.Address?.PostCode,
                    City = item.Address?.City
                };
            }
            return null;
        }
    }
}