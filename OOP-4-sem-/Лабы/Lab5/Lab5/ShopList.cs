using System;
using System.Collections.Generic;

namespace Lab5
{
    [Serializable]
    public class ShopList
    {
        public List<Product> Products { get; set; }
        public ShopList() => Products = new List<Product>();
    }
}
