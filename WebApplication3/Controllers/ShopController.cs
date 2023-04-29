using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View( );
        }


        private readonly TableContext _context;

        public ShopController(TableContext context)
        {
            _context = context;
        }

      

       // [HttpGet] 
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return View(await _context.Products.ToListAsync());
        }

    }
}
