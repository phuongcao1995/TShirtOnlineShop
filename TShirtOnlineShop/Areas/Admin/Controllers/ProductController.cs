using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var customer = Session["Customer"] as Customer;
            if (customer == null || customer.Type != 1)
            {
                return RedirectToAction("SignIn", "Home");
            }
            return View();
        }
        public JsonResult Data()
        {
            var list = db.Products.Where(x=>x.Status!=false).OrderByDescending(x => x.ID).ToList();
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
            Product Product = Mapper.Map<Product>(product);
            Product.Status = true;
            db.Products.Add(Product);
            db.SaveChanges();
            if (!String.IsNullOrEmpty(product.UpLoad))
            {
                System.Drawing.Image img = AspMantraBase64ToImage(product.UpLoad.Split(',')[1]);
                var path = "/Content/images/" + DateTime.Now.Ticks.ToString() + "1.jpg";
                img.Save(Server.MapPath(path));
                Image image = new Image()
                {
                    Path = path,
                    ProductID = Product.ID
                };
                db.Images.Add(image);
                db.SaveChanges();
            }
            if (!String.IsNullOrEmpty(product.UpLoad2))
            {
                System.Drawing.Image img2 = AspMantraBase64ToImage(product.UpLoad2.Split(',')[1]);
                var path2 = "/Content/images/" + DateTime.Now.Ticks.ToString() + "2.jpg";
                img2.Save(Server.MapPath(path2));
                Image image2 = new Image()
                {
                    Path = path2,
                    ProductID = Product.ID
                };
                db.Images.Add(image2);
                db.SaveChanges();
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditProduct(ProductViewModel product)
        {
            Product Product = Mapper.Map<Product>(product);
            db.Entry(Product).State = EntityState.Modified;
            db.SaveChanges();
            if (!String.IsNullOrEmpty(product.UpLoad))
            {
                System.Drawing.Image img = AspMantraBase64ToImage(product.UpLoad.Split(',')[1]);
                var path = "/Content/images/" + DateTime.Now.Ticks.ToString() + "1.jpg";
                img.Save(Server.MapPath(path));
                Image image = db.Images.FirstOrDefault(x => x.ProductID == Product.ID);
                image.Path = path;
                db.SaveChanges();
            }
            if (!String.IsNullOrEmpty(product.UpLoad2))
            {
                System.Drawing.Image img2 = AspMantraBase64ToImage(product.UpLoad2.Split(',')[1]);
                var path2 = "/Content/images/" + DateTime.Now.Ticks.ToString() + "2.jpg";
                img2.Save(Server.MapPath(path2));
                Image image = db.Images.Where(x => x.ProductID == Product.ID).ToList().Last();

                image.Path = path2;
                db.SaveChanges();
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteProduct(ProductViewModel product)
        {
            Product Product = Mapper.Map<Product>(product);
            Product.Status = false;
            db.Entry(Product).State = EntityState.Modified;
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