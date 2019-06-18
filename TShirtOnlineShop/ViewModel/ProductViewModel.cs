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
        public string Size { get; set; }
        public string Colors { get; set; }
        public Nullable<decimal> PromotionPrice { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public List<string> ImagesName { get; set; }
        public List<int> ImagesID{ get; set; }

        public Nullable<decimal> PriceTotal { get; set; }
        public string Description { get; set; }
    }
}