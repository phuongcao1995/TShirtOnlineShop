using AutoMapper;
using System.Web.Mvc;
using TShirtOnlineShop.Models;
using TShirtOnlineShop.ViewModel;

namespace TShirtOnlineShop.Controllers
{
    //comment 2
    public class ChildController : BaseController
    {
        OnlineShopEntities db = new OnlineShopEntities();
        public ActionResult Boys()
        {
            ViewBag.Type = 9;
            return View();
        }
        public ActionResult Girls()
        {
            ViewBag.Type = 10;
            return View();
        }        
        public ActionResult Detail(int id)
        {
            ViewBag.productId = id;
            return View();
        }
        //public JsonResult Data(int? type)
        //{
        //    var list = db.Products.Where(x => x.CategoryID == type).OrderByDescending(x => x.ID).ToList();
        //    return Json(Mapper.Map<List<ProductViewModel>>(list), JsonRequestBehavior.AllowGet);
        //}
        public JsonResult ProductDetail(int id)
        {
            var product = db.Products.Find(id);
            return Json(Mapper.Map<ProductViewModel>(product), JsonRequestBehavior.AllowGet);
        }


    }
}