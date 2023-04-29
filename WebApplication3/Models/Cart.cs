using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
	public class Cart
	{
		[Key]
		public int cart_id
		{
			get;
			set;
		}
		
		public int product_id { get; set; }

		public int customer_id { get; set; }

	
		public string product_name { get; set; }

		public string car_model { get; set; }
		public int stock { get; set; }
		public double price { get; set; }

		public int quantity { get; set; }
	}
}
