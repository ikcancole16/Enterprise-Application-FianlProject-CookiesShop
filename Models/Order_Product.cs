using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookiesShop.Models
{
    public class Order_Product
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Order Order { get; set; }
    }
}