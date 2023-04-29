using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }

        public string address { get; set; }

        public DateTime? order_date { get; set; }

        public ICollection<Product> Products { get; set; }

        public int customer_id { get; set; }
        public int product_id { get; set; }

    }
}
