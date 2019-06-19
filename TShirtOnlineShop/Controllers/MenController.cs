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
            ViewBag.productId=id;
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
            return Json(Mapper.Map<ProductViewModel>(product), JsonRequestBehavior.AllowGet);
        }

       
    }
}