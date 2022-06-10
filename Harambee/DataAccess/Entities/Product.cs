using System.ComponentModel.DataAnnotations;

namespace Harambee.DataAccess.Entities
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int BundleID { get; set; }
        public Bundle Bundle { get; set; }
    }
}
