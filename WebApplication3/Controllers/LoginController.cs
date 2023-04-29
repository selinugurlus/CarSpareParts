using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class LoginController : Controller
    {
        private readonly TableContext _context;

        public LoginController(TableContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult Register(Customer customer)
        {
            var newcustomer = new Customer()
            {
                customer_id = customer.customer_id,
                customer_firstname=customer.customer_firstname,
                customer_lastname=customer.customer_lastname,
                customer_mail=customer.customer_mail,
                customer_pass=customer.customer_pass,
                
            };

            _context.Customers.Add(newcustomer);
            _context.SaveChanges();
            //return RedirectToAction("GetProducts");
       
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer customer)
        {

            //var useruserinfo = _context.Customers.FirstOrDefault(x => x.customer_mail== c.customer_mail &&
            //    x.customer_pass == c.customer_pass); 

            var status = _context;
            
          


                                                     // var useruserinfo = ulm.GetUser(a.user_mail, a.user_password);
                                                     //if (useruserinfo != null)
                                                     //{
                                                     //    FormsAuthentication.SetAuthCookie(useruserinfo.user_mail, false);
                                                     //    Session["user_mail"] = useruserinfo.user_mail;
                                                     //    return RedirectToAction("MyContent", "UserPanelContent");
                                                     //}
                                                     //else
                                                     //{
                                                     //    Response.Write("<script language='javascript'>alert(\"Hatalı Kullanıcı Adı veya Şifre Girdiniz\")</script>");
                                                     //    return RedirectToAction("UserLogin");

            //}
            return View();

        }
    }
}
