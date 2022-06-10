using System.Collections.Generic;

namespace Harambee.DataAccess.Entities
{
    public class Basket
    {
        public int CustomerID { get; set; }

        public List<Product> Products { get; set; }
    }
}
