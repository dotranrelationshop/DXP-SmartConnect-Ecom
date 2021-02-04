using DXP.SmartConnect.Ecom.Core.DTOs;
using System.Threading.Tasks;

namespace DXP.SmartConnect.Ecom.Core.Interfaces
{
    public interface ICartService
    {
        /// <summary>
        /// Get the cart detail of user.
        /// </summary>
        /// <param name="userName">The owner's id or username of the cart </param>
        /// <param name="storeId">The store id </param>
        /// <returns>The cart detail</returns>
        Task<CartDto> GetCart(string userName, string storeId);
    }
}
