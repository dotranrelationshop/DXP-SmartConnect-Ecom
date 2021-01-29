using DXP.SmartConnect.Ecom.SharedKernel;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class ProductUnit : BaseEntity
    {
        public string Abbreviation { set; get; }
        public string Type { set; get; }
        public string Label { set; get; }
        public string Size { set; get; }
    }
}
