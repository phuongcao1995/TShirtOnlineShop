﻿using System;

namespace TShirtOnlineShop.ViewModel
{
    public class CartViewModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public ProductViewModel Product { get; set; }
        public Nullable<int> Quantity { get; set; }
    }
}