using Harambee.DataAccess.Entities;
using System.Threading.Tasks;

namespace Harambee.DataAccess.Services.Contracts
{
    public interface ICartService
    {
        public Basket AddToBasket(int customerID, int productID);
        public decimal GetBasketValue(int customerID);
    }
}
