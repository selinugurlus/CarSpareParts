using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Car
    {
        [Key]
        public int car_id { get; set; }
        public string car_brand { get; set; }
        public string car_model { get; set; }
        public int car_year { get; set; }
        //public ICollection<Product> Product { get; set; }
    }
}
