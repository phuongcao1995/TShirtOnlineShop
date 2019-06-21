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

        public ActionResult Shipping()
        {
            ViewBag.total = TempData["total"];
            return View();
        }

        [HttpPost]
        public ActionResult CheckOutOrder(List<CartViewModel> ShoppingCart)
        {
            //List<CartViewModel> cartViewModel = new List<CartViewModel>();
            //HttpCookie Cookie = HttpContext.Request.Cookies["CartCookie"];// lấy cookie
            //string ValueCookie = Server.UrlDecode(Cookie.Value);//Decode dịch ngược mã  các ký tự đặc biệt tham khảo http://www.aspnut.com/reference/encoding.asp
            //cartViewModel = JsonConvert.DeserializeObject<List<CartViewModel>>(ValueCookie);// convert json to  list object  

            Order order = new Order()
            {
                CustomerID = (Session["customer"] as Customer).ID,
                Status = "ordered",
                CreatedDate = DateTime.Now
            };

            db.Orders.Add(order);
            db.SaveChanges();
            decimal? total = 0;
            foreach (var item in ShoppingCart)
            {
                var product = db.Products.Find(item.ProductID);
                total += (1 - product.PromotionPrice/100) * product.Price * item.Quantity;
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderID = order.ID,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    

                };
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
            }
            TempData["total"] =  decimal.Parse("1.1") *total;
            Response.Cookies["CartCookie"].Value = "[]";
            return Json("");
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