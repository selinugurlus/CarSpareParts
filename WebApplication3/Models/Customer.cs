using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Customer
    {
        [Key]
        public int customer_id { get; set; }

        [StringLength(20)]
        public string customer_firstname { get; set; }

        [StringLength(20)]
        public string customer_lastname { get; set; }

        [StringLength(100)]
        public string customer_mail { get; set; }

        [StringLength(20)]
        public string customer_pass { get; set; }


        public ICollection<Order> Orders { get; set; }
    }
}
