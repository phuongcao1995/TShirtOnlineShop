using System;
using System.Collections.Generic;
using TShirtOnlineShop.Models;

namespace TShirtOnlineShop.ViewModel
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerEmail { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public List<OrderDetailViewModel> OrderDetailViewModel { get; set; }
        public decimal Total { get; set; }
    }
}