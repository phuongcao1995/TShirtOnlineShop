using System.Linq;
using System.Web.Mvc;
using TShirtOnlineShop.Models;

namespace TShirtOnlineShop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        OnlineShopEntities db = new OnlineShopEntities();

        public ActionResult SignIn()
        {
            var customer = Session["Customer"] as Customer;
            if (customer != null && customer.Type==1)
            {
                return RedirectToAction("index", "Product");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(Customer customer)
        {

            if (ModelState.IsValid)
            {
                var customerLogin = db.Customers.Where(x => x.CustomerEmail == customer.CustomerEmail && x.CustomerPassword == customer.CustomerPassword);
                if (customerLogin.Count() == 0)
                {
                    ModelState.AddModelError("", "Account doesn't exist");
                    return View();
                }
                else if (customerLogin.First().Type!=1)
                {
                    ModelState.AddModelError("", "Account doesn't exist");
                    return View();
                }
                else
                {
                    Session["customer"] = customerLogin.FirstOrDefault();
                    return RedirectToAction("index", "Product");
                }
            }
            ModelState.AddModelError("", "Email or Password is not correct");
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("SignIn", "Home");
        }
    }
}