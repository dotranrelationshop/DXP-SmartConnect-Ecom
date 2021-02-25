using DXP.SmartConnect.Ecom.SharedKernel;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CartTprInfo : BaseEntity<string>
    {
        public decimal Markdown { set; get; }
        public string EffectiveFrom { set; get; }
        public string EffectiveUntil { set; get; }
        public string Label { set; get; }
    }
}