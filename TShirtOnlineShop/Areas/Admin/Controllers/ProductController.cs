using AutoMapper;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TShirtOnlineShop.Models;
using TShirtOnlineShop.ViewModel;

namespace TShirtOnlineShop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private OnlineShopEntities db = new OnlineShopEntities();
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Data()
        {
            var list = db.Products.OrderByDescending(x => x.ID).ToList();
            return Json(Mapper.Map<List<ProductViewModel>>(list), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCategoryByType(int type)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var category = db.Categories.Where(x=>x.Type==type).ToList();
            return Json(category, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult ProductDetail(int id)
        {
            var product = db.Products.Find(id);
            return Json(Mapper.Map<ProductViewModel>(product), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddProduct(ProductViewModel product)
        {
            System.Drawing.Image img = AspMantraBase64ToImage(product.UpLoad.Split(',')[1]);
            System.Drawing.Image img2 = AspMantraBase64ToImage(product.UpLoad2.Split(',')[1]);
            var path = "/Content/images/" + DateTime.Now.Ticks.ToString() + "1.jpg";
            var path2 = "/Content/images/" + DateTime.Now.Ticks.ToString() + "2.jpg";
            img.Save(Server.MapPath(path));
            img2.Save(Server.MapPath(path2));
            Product Product = Mapper.Map<Product>(product);
            db.Products.Add(Product);
            db.SaveChanges();
            Image image = new Image()
            {
                Path = path,
                ProductID = Product.ID
            };
            Image image2 = new Image()
            {
                Path = path2,
                ProductID = Product.ID
            };
            db.Images.Add(image);
            db.Images.Add(image2);
            db.SaveChanges();

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public System.Drawing.Image AspMantraBase64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
    }
}