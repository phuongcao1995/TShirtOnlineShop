using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TShirtOnlineShop.Models;
using TShirtOnlineShop.ViewModel;

namespace TShirtOnlineShop.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        OnlineShopEntities db = new OnlineShopEntities();
        public ActionResult Index()
        {
            var customer = Session["Customer"] as Customer;
            if (customer == null || customer.Type != 1)
            {
                return RedirectToAction("SignIn", "Home");
            }
            return View();
        }

        public JsonResult Data()
        {
            var list = db.Orders.OrderByDescending(x => x.ID).ToList();
            var listOrderViewModel = Mapper.Map<List<OrderViewModel>>(list);
            if (listOrderViewModel != null)
            {
              
                foreach (var item in listOrderViewModel)
                {                
                    var orderDetail = db.OrderDetails.Where(x => x.OrderID == item.ID);
                    item.OrderDetailViewModel = Mapper.Map<List<OrderDetailViewModel>>(orderDetail);
                    if (item.OrderDetailViewModel != null)
                    {
                        decimal? total = 0;
                        foreach (var subItem in item.OrderDetailViewModel)
                        {
                            var product = db.Products.Find(subItem.ProductID);
                            total += (1 - product.PromotionPrice / 100) * product.Price * subItem.Quantity;
                        }
                        item.Total = total.Value;
                    }
                   
                }
            }
            return Json(listOrderViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}