using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookiesShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<Order_Product> Order_Products { get; set; }

    }
}