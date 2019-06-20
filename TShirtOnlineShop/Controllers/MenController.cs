using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TShirtOnlineShop.Models;
using TShirtOnlineShop.ViewModel;

namespace TShirtOnlineShop.Controllers
{
    public class MenController : BaseController
    {
        OnlineShopEntities db = new OnlineShopEntities();
        public ActionResult LongSleeves()
        {
            ViewBag.Type = 1;
            return View();
        }
        public ActionResult ShortSleeves()
        {
            ViewBag.Type = 2;
            return View();
        }
        public ActionResult PoloSleeves()
        {
            ViewBag.Type = 3;
            return View();
        }
        public ActionResult Detail(int id)
        {
            ViewBag.productId = id;
            return View();
        }
        public JsonResult Data(string size, string colors, int? price, int? type)
        {
            var list = db.Products.Where(x => x.CategoryID == type);

            if (!string.IsNullOrWhiteSpace(size))
            {
                list = list.Where(x => x.Size.Equals(size, StringComparison.OrdinalIgnoreCase));
            }
            if (price != null && price == 1)
            {
                list = list.Where(x => x.Price < 10);
            }
            else if (price != null && price == 2)
            {
                list = list.Where(x => x.Price < 20);
            }
            else if (price != null && price == 3)
            {
                list = list.Where(x => x.Price > 20);
            }
            if (!string.IsNullOrWhiteSpace(colors))
            {
                list = list.Where(x => x.Colors.Equals(colors, StringComparison.OrdinalIgnoreCase));
            }

            return Json(Mapper.Map<List<ProductViewModel>>(list.OrderByDescending(x => x.ID)), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductDetail(int id)
        {
            var product = db.Products.Find(id);
            var anotherProduct = db.Products.Where(x => x.Category.Type == product.Category.Type && x.Status != false && x.ID != id).Take(4).ToList();
            return Json(new
            {
                product = Mapper.Map<ProductViewModel>(product),
                anotherProduct = Mapper.Map<List<ProductViewModel>>(anotherProduct)
            },
                JsonRequestBehavior.AllowGet);

        }
    }
}