using DXP.SmartConnect.Ecom.SharedKernel;

namespace DXP.SmartConnect.Ecom.Core.Entities
{
    public class CartReward : BaseEntity<string>
    {
        public string RewardId { set; get; }
        public decimal Points { set; get; }
        public int ProductQuantity { set; get; }
        public decimal RewardPrice { set; get; }
    }
}