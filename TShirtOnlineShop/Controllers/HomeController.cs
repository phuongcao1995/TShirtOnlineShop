using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;

using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TShirtOnlineShop.Models;
using TShirtOnlineShop.ViewModel;

namespace TShirtOnlineShop.Controllers
{
    public class HomeController : Controller
    {
        Function function = new Function();
        private OnlineShopEntities db = new OnlineShopEntities();

        public ActionResult HomePage()
        {
            var listBestSeller = db.Products.Where(x => x.Status != false).OrderByDescending(x => x.PromotionPrice).Take(6).ToList();
            var list = db.Products.OrderByDescending(x => x.ID).ToList();
            ViewBag.listBestSeller = Mapper.Map<List<ProductViewModel>>(listBestSeller);
            return View(Mapper.Map<List<ProductViewModel>>(list));
        }

        public ActionResult MenShortSleeves()
        {
            return View();
        }
        public ActionResult SignIn()
        {
            if (Session["Customer"] != null)
            {
                return RedirectToAction("HomePage", "Home");
            }
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult ShoppingCart()
        {
            return View();
        }

        public ActionResult SearchBar()
        {
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
                    ModelState.AddModelError("", "Customer doesn't exist");
                    return View();
                }
                else
                {
                    Session["customer"] = customerLogin.FirstOrDefault();
                    return RedirectToAction("HomePage", "Home");
                }
            }
            ModelState.AddModelError("", "Email or Password is not correct");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Customer customer)
        {
            if (ModelState.IsValid)
            {
                //db.Customers.Add(customer);
                db.Entry(customer).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("HomePage");
            }

            return View("SignUp");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Response.Cookies["CartCookie"].Value = "[]";
            return RedirectToAction("HomePage", "Home");
        }
    }
}