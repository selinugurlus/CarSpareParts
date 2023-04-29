using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using System.Configuration;




namespace WebApplication3.Controllers
{
    public class CartController : Controller
    {
        private readonly TableContext _context;

        public CartController(TableContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = (int)cart.Sum(x => x.quantity * x.price)
            };





            return View(cartVM);


        }

        public async Task<IActionResult> Add(int id)
        {
            Product product = await _context.Products.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(c => c.product_id == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }

            else
            {
                cartItem.quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            TempData["Succes"] = "The product has been added";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<ActionResult> CreateOrderAsync(Order order)
        {
            var neworder = new Order()
            {
                //order_date = order.order_date,
                address = order.address,
                order_id = order.order_id,
                customer_id = order.customer_id,
               
            };
            //HttpContext context = HttpContext.Current;
            //List<CartItem> Cart = (List<CartItem>)context.Session["Cart"];


            //List<CartItem> Cart = (List<CartItem>)Session["Cart"];

            //for (int i = 0; i < Cart.Count; i++)
            //{
            //    neworder.product_id = Cart[i].product_id;
            //}

            //List<CartItem> Cart = HttpContext.Session.Get<List<CartItem>>("Cart");



            //for (int i = 0; i < Cart.Count; i++)
            //{
            //    neworder.product_id = Cart[i].product_id;
            //}


            //List<CartItem> Cart = await HttpContext.Session.GetJsonAsync<List<CartItem>>("Cart");

            //for (int i = 0; i < Cart.Count; i++)
            //{
            //    neworder.product_id = Cart[i].product_id;
            //}


            _context.Orders.Add(neworder);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CheckOut()
        {
            return View("CheckOut");
        }


        



            //public IActionResult Clear()
            //{
            //    HttpContext.Session.Remove("Cart");

            //    return RedirectToAction("Index");
            //}

            //public async Task<IActionResult> Remove(int id)
            //{
            //    List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            //    cart.RemoveAll(p => p.product_id == id);

            //    if (cart.Count == 0)
            //    {
            //        HttpContext.Session.Remove("Cart");
            //    }
            //    else
            //    {
            //        HttpContext.Session.SetJson("Cart", cart);
            //    }

            //    TempData["Success"] = "The product has been removed!";

            //    return RedirectToAction("Index");
            //}


            //  public  IActionResult  Decrease(int id)
            //  {


            //List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            //      CartItem cartItem = cart.Where(c => c.product_id == id).FirstOrDefault();

            //      if (cartItem.quantity > 1)
            //      {
            //	--cartItem.quantity;
            //      }

            //      else
            //      {
            //	cart.RemoveAll(x => x.product_id == id);
            //      }

            //if(cart.Count==0)
            //{
            //          HttpContext.Session.Remove("Cart");
            //      }
            //else
            //{
            //          HttpContext.Session.SetJson("Cart", cart);
            //      }


            //      TempData["Succes"] = "The product has been added";

            //      return Redirect(Request.Headers["Referer"].ToString());
            //  }
        }
    }

