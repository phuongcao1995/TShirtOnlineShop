using AutoMapper;
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
        public JsonResult Data(int? type)
        {
            var list = db.Products.Where(x => x.CategoryID == type).OrderByDescending(x => x.ID).ToList();
            return Json(Mapper.Map<List<ProductViewModel>>(list), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductDetail(int id)
        {
            var product = db.Products.Find(id);
            var anotherProduct = db.Products.Where(x => x.Category.Type == product.Category.Type && x.Status != false && x.ID!= id).Take(4).ToList();
            return Json(new
            {
                product = Mapper.Map<ProductViewModel>(product),
                anotherProduct = Mapper.Map<List<ProductViewModel>>(anotherProduct)
            },
                JsonRequestBehavior.AllowGet);

        }
    }
}