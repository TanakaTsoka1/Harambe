using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Harambee.DataAccess.Entities
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
