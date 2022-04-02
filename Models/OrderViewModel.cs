using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookiesShop.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShippingAddress { get; set; }
        public string Note { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}