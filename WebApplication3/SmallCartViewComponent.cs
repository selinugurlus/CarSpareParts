using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;


namespace WebApplication3
{
	public class SmallCartViewComponent : ViewComponent
	{

		public IViewComponentResult Invoke()
			{
			List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
			SmallCartViewModel smallCartVM;

			if(cart==null || cart.Count==0)
			{
				smallCartVM = null;
			}
			else
			{
				smallCartVM = new()
				{
					number_of_items = cart.Sum(x => x.quantity),
					total_amount = (int)cart.Sum(x => x.quantity * x.price)
				};
			}

			return View(smallCartVM);
			}
	}
}
