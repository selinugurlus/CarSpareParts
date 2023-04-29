
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WebApplication3.Models;


namespace WebApplication3.Controllers
{
   // [Route("api/[controller]")]
   // [ApiController]
    public class ProductController : Controller
    {
       

        private readonly TableContext _context;

        public ProductController(TableContext context)
        {
            _context = context;
        }

        //ProductRepository productRepository = new ProductRepository();


        //  return View(//productRepository.GetAll()
        //);


        // GET: api/Products

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return View(await _context.Products.ToListAsync());
        }
        
       

        // GET: api/Products/5
      
        public ActionResult GetProductByID(int id)
        {
            var product = _context.Products.Where(p => p.product_id == id);
            return View(product);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            // var NewProduct = new Product();
            //_context.Add(NewProduct);
            // _context.SaveChanges();
            return View();//NewProduct);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            var newproduct = new Product()
            {
                product_id = product.product_id,
                product_name = product.product_name,
                //car_id = product.car_id,
                stock = product.stock,
                price = product.price,
                image = product.image,
                car_model=product.car_model
            };

            _context.Products.Add(newproduct);
            _context.SaveChanges();
            return RedirectToAction("AddProduct");
            //return View();
        }



        public ActionResult DeleteProduct (int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.product_id == id);
            if(product!=null)
            {
                _context.Remove(product);
                _context.SaveChanges();
                return RedirectToAction("GetProducts");
            }
            return RedirectToAction("GetProducts");
        }

        //[HttpPost]
        //public  ActionResult DeleteProduct(Product product)
        //{
        //   var deleteproduct= _context.Products.Find(product.product_id);
        //    //var deleteproduct = _context.Products.Where(p => p.product_id == id);
        //    if (deleteproduct!=null)
        //    {
        //        _context.Products.Remove(deleteproduct);
        //        _context.SaveChanges();
        //        return RedirectToAction("GetProducts");
        //    }

        //    return RedirectToAction("GetProducts");
        //}

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();

            return RedirectToAction("GetProducts");
        }

        //public ActionResult UpdateProduct([Bind("product_id,product_name,car_id,stock,price,image")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Update(product);
        //        _context.SaveChanges();
        //        return RedirectToAction("GetProducts");
        //    }
        //    return View(product);
        //}



        //public ActionResult UpdateProduct(int id)
        //{
        //    var product = _context.Products.Where(p => p.product_id == id);

        //    var newproduct = new Product()
        //    {
        //        product_id = product.product_id,
        //        product_name = product.product_name,
        //        car_id = product.car_id,
        //        stock = product.stock,
        //        price = product.price,
        //        image = product.image
        //    };

        //    return View();
        //}


    }
}
