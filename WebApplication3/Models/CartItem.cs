namespace WebApplication3.Models
{
	public class CartItem
	{
		public int product_id { get; set; }
		public string product_name { get; set; }
		public int quantity { get; set; }
		public double price { get; set; }
		public int total
		{
			get { return (int)(quantity * price); }
		
		}
		public CartItem()
		{

		}

        public CartItem(Product product)
        {
			product_id = product.product_id;
			product_name = product.product_name;
			quantity = 1;
			price = product.price;
				
        }
    }
}
