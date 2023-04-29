using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using static NuGet.Packaging.PackagingConstants;

namespace WebApplication3.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TableContext _context;

        public CustomerController(TableContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

       // [HttpGet]
        public ActionResult MyOrder(int id)
        {
           

            var orders =_context.Orders.Where(p => p.customer_id == id);
            return View(orders);
      
        }
        //[HttpGet]
        //public ActionResult CustomerProfile(int id = 0)
        //{

        //    string p = (string)["user_mail"];
        //    id = c.Customers.Where(x => x.user_mail == p).Select(y => y.user_id).FirstOrDefault();
        //    var uservalue = um.GetByID(id);
        //    return View(uservalue);
        //}
    }
}
