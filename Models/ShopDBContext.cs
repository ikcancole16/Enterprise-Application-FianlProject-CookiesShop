using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CookiesShop.Models
{
    public class ShopDBContext : DbContext
    {
        public ShopDBContext():base("DefaultConnection")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order_Product> Order_Products { get; set; }

    }
}