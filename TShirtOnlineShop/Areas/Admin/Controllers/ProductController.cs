using AutoMapper;
using System;
using System.Collections.Generic;
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

        public JsonResult ProductDetail(int id)
        {
            var product = db.Products.Find(id);
            return Json(Mapper.Map<ProductViewModel>(product), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddProduct()
        {
            var a= UploadImage();
            return Json(null, JsonRequestBehavior.AllowGet);
        }


        public string UploadImage()
        {
            DateTime dateTime = DateTime.Now;
            string tick = dateTime.Ticks.ToString();
            string fname = "";
            string path = null; ;
            int size = 0;
            List<string> LIST_IMAGE_TYPE = new List<string>() { ".jpg", ".jpeg", ".gif", ".png" };
            List<dynamic> media = new List<dynamic>();

            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {

                        HttpPostedFileBase file = files[i];
                        string extension = Path.GetExtension(file.FileName).ToLowerInvariant();

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                            size = file.ContentLength / 1024;
                        }
                        if (LIST_IMAGE_TYPE.Contains(extension))
                        {
                            fname = Path.Combine(Server.MapPath("~/Content/images"), tick + extension);
                            file.SaveAs(fname);
                            path = "/Content/images/" + tick + extension;
                        }

                        media.Add(new { url = path });
                    }

                }

                catch (Exception)
                {
                    return path;
                }

            }
            return path;
        }
    }
}