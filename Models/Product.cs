using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookiesShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int  Quantity{ get; set; }
        public string ProductName { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }
        public string CakeType { get; set; }
        public string CreanType { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }
}