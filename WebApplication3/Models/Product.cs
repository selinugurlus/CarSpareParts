using System.ComponentModel.DataAnnotations;
using WebApplication3.Models;



namespace WebApplication3.Models
{
    public class Product
    {
        [Key]
        public int product_id { get; set; }

        [StringLength(40)]
        public string product_name { get; set; }

        public string car_model { get; set; }
        public int stock { get; set; }
        public double price { get; set; }
        public string image { get; set; } //??


        //public int car_id { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
