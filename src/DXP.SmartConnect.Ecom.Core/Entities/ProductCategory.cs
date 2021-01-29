using DXP.SmartConnect.Ecom.SharedKernel;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class ProductCategory : BaseEntity
    {
        public string CategoryId { set; get; }
        public string RetailerId { set; get; }
        public string Category { set; get; }
        public string CategoryBreadcrumb { set; get; }
    }
}
