using System;
using System.Collections.Generic;

namespace TShirtOnlineShop.ViewModel
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int Type { get; set; }
        public string TypeName => (Type == 1) ? "Men" : ((Type == 2) ? "Women" : "Child");
        public string Size { get; set; }
        public string Colors { get; set; }
        public string ColorsName => (Colors == "R") ? "Red" : ((Colors == "Y") ? "Yellow" : "Black");
        public Nullable<decimal> PromotionPrice { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool Status { get; set; }
        public List<string> ImagesName { get; set; }
        public List<int> ImagesID { get; set; }
        public string UpLoad { get; set; }
        public string UpLoad2 { get; set; }
        public Nullable<decimal> PriceTotal { get; set; }
        public string Description { get; set; }
		// public string Description { get; set; }
		// public Nullable<decimal> PriceTotal { get; set; }
    }

}