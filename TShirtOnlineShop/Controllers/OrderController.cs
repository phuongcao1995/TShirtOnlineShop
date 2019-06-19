using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TShirtOnlineShop.Models;
using TShirtOnlineShop.ViewModel;

namespace TShirtOnlineShop.Controllers
{
    public class OrderController : Controller
    {
        private OnlineShopEntities db = new OnlineShopEntities();

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult ShoppingCart()
        {
            return View();
        }
        public JsonResult GetShoppingCart()
        {
            List<CartViewModel> cartViewModel = new List<CartViewModel>();
            HttpCookie Cookie = HttpContext.Request.Cookies["CartCookie"];// lấy cookie
            if (Cookie != null)// check cookies có value nếu cookie not null
            {
                string ValueCookie = Server.UrlDecode(Cookie.Value);//Decode dịch ngược mã  các ký tự đặc biệt tham khảo http://www.aspnut.com/reference/encoding.asp
                cartViewModel = JsonConvert.DeserializeObject<List<CartViewModel>>(ValueCookie);// convert json to  list object  
                foreach (var item in cartViewModel)
                {
                    item.Product = Mapper.Map<ProductViewModel>(db.Products.Find(item.ProductID));
                }
            }
            return Json(cartViewModel, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddCart(int productId, string productName)
        {
            List<CartViewModel> cartViewModel = new List<CartViewModel>();
            HttpCookie Cookie = HttpContext.Request.Cookies["CartCookie"];// lấy cookie
            if (Cookie != null)// check cookies có value nếu cookie not null
            {
                string ValueCookie = Server.UrlDecode(Cookie.Value);//Decode dịch ngược mã  các ký tự đặc biệt tham khảo http://www.aspnut.com/reference/encoding.asp
                ViewBag.ValueCookie = ValueCookie;// show value cookie to View
                cartViewModel = JsonConvert.DeserializeObject<List<CartViewModel>>(ValueCookie);// convert json to  list object
                CartViewModel newcart = new CartViewModel();

                if (cartViewModel.Any(x => x.ProductID == productId))
                {
                    foreach (var item in cartViewModel)
                    {
                        if (item.ProductID == productId)
                        {
                            item.Quantity += 1;
                        }
                    }
                }
                else
                {
                    newcart.ProductID = productId;
                    newcart.ProductName = productName;
                    newcart.Quantity = 1;
                    cartViewModel.Add(newcart);// add object to List
                }


                string jsonItem = JsonConvert.SerializeObject(cartViewModel, Formatting.Indented);
                HttpCookie cookie = new HttpCookie("CartCookie");// create 
                cookie.Value = Server.UrlEncode(jsonItem);//Encode dịch  mã  các ký tự đặc biệt, từ string  => tham khảo http://www.aspnut.com/reference/encoding.asp
                HttpContext.Response.Cookies.Add(cookie);// cookie mới đè lên cookie cũ
                ViewBag.ValueCookie = cookie.Value;// show value cookie to View
            }
            else//cookie chưa có / cookie is null 
            {
                CartViewModel newcart = new CartViewModel();
                newcart.ProductID = productId;
                newcart.ProductName = productName;
                newcart.Quantity = 1;
                cartViewModel.Add(newcart);// add object to List
                                           //do something

                //convert từ List<> to =>  json string
                string jsonItem = JsonConvert.SerializeObject(cartViewModel, Formatting.Indented);
                //cookie
                HttpCookie cookie = new HttpCookie("CartCookie");// create 
                cookie.Value = Server.UrlEncode(jsonItem);//Encode dịch  mã  các ký tự đặc biệt, từ string  => tham khảo http://www.aspnut.com/reference/encoding.asp
                HttpContext.Response.Cookies.Add(cookie);// cookie mới đè lên cookie cũ
                ViewBag.ValueCookie = cookie.Value;// show value cookie to View
            }
            return Json(cartViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult RemoveProduct(int productId)
        {
            List<CartViewModel> cartViewModel = new List<CartViewModel>();
            HttpCookie Cookie = HttpContext.Request.Cookies["CartCookie"];// lấy cookie

            string ValueCookie = Server.UrlDecode(Cookie.Value);//Decode dịch ngược mã  các ký tự đặc biệt tham khảo http://www.aspnut.com/reference/encoding.asp
            ViewBag.ValueCookie = ValueCookie;// show value cookie to View
            cartViewModel = JsonConvert.DeserializeObject<List<CartViewModel>>(ValueCookie);// convert json to  list object
            cartViewModel.Remove(cartViewModel.FirstOrDefault(x => x.ProductID == productId));           
            foreach (var item in cartViewModel)
            {
                item.Product = Mapper.Map<ProductViewModel>(db.Products.Find(item.ProductID));
            }
            string jsonItem = JsonConvert.SerializeObject(cartViewModel, Formatting.Indented);
            HttpCookie cookie = new HttpCookie("CartCookie");// create 
            cookie.Value = Server.UrlEncode(jsonItem);//Encode dịch  mã  các ký tự đặc biệt, từ string  => tham khảo http://www.aspnut.com/reference/encoding.asp
            HttpContext.Response.Cookies.Add(cookie);// cookie mới đè lên cookie cũ
            return Json(cartViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}