using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TShirtOnlineShop.ViewModel
{
    public class OrderDetailViewModel
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public Nullable<int> Quantity { get; set; }
    }
}