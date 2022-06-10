using Harambee.DataAccess.DbContext;
using Harambee.DataAccess.Entities;
using Harambee.DataAccess.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Harambee.DataAccess.Services.Implementations
{
    public class CartService : ICartService
    {
        private EntityContext _entityContext;
        private List<Basket> baskets;

        public CartService(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public Basket AddToBasket(int customerID, int productID)
        {
            // This code should use repos and not query the entityContext. Due to time constraints it was done as below.

            Basket basket = baskets.Where(x => x.CustomerID == customerID).FirstOrDefault();
            
            List<Product> products = new List<Product>();
            Bundle bundle = _entityContext.Bundles.AsNoTracking().Where(x => x.Products.Any(y => y.ID == productID)).FirstOrDefault();

            // Add bundle prods if any
            if (bundle != null)
                products.AddRange(bundle.Products);
            else // otherwise add just the original product
            {
                Product product = _entityContext.Products.AsNoTracking().Where(x => x.ID == productID).FirstOrDefault();
                products.Add(product);
            }
                
            // If basket doesnt exist
            if (basket == null)
            {
                baskets.Add(new Basket() { 
                    CustomerID = customerID,
                    Products = products
                });
            }
            else // If it exists
                basket.Products.AddRange(products);

            return basket;
        }

        public decimal GetBasketValue(int customerID)
        {
            Basket currBasket = baskets.Where(x => x.CustomerID == customerID).FirstOrDefault();
            return currBasket.Products.Sum(x => x.Price);
        }
    }
}
