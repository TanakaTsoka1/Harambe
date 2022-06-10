using System.ComponentModel.DataAnnotations;

namespace Harambee.DataAccess.Entities
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Email { get; set; }
    }
}
