using CookiesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookiesShop.Controllers
{
    public class HomeController : Controller
    {
        //This is main home page/ shop
        public ActionResult Index()
        {
            //ViewBag.UserId = Session["userId"];
            using (ShopDBContext db = new ShopDBContext())
            {
                var list = db.Products.ToList();
                return View(list);
            }
        }
        //Display Order page to add shipping address and note
        public ActionResult Order()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Login","Account",new { returnUrl="./Home/Order"});
            }
            List<Product> cart = (List<Product>)Session["cart"];
            ViewBag.total = cart.Sum(x => x.Price);
            return View();
        }
        //Add new order to datatbase
        [HttpPost]
        public ActionResult PostOrder(Order order)
        {
            //if (Session["userId"] == null)
            //{
            //    return RedirectToAction("Login","Account");
            //}
            if (order.ShippingAddress == null || order.UserId <=0)
            {
                ViewBag.error = "Please fill all the fields carefully.";
                return View("Order");
            }
            using (ShopDBContext db = new ShopDBContext())
            {
                order.CreatedAt = DateTime.Now;
                db.Orders.Add(order);
                db.SaveChanges();
                List<Product> cart = (List<Product>)Session["cart"];
                foreach (var item in cart)
                {
                    Order_Product po = new Order_Product
                    {
                        OrderId=order.Id,
                        ProductId=item.Id,
                        Quantity=item.Quantity,
                        Price=item.Price
                    };
                    db.Order_Products.Add(po);
                    db.SaveChanges();
                }
                Session["cart"] = null;
                return RedirectToAction("Success", new { orderId = order.Id });
            }
            // return View();
        }
        //This function is responsible to display product details
        public ActionResult ProductDetail(int Id = 0)
        {
            using (ShopDBContext db = new ShopDBContext())
            {
                Product pro = db.Products.Find(Id);
                var detail = db.Products.Where(x => x.Id == Id).FirstOrDefault();
                return View(detail);
            }
        }
        //Thank you page after placing order
        public ActionResult Success(int orderId = 0)
        {
            //if (orderId <= 0)
            //{
            //    return RedirectToAction("Index");
            //}
            using (ShopDBContext db = new ShopDBContext())
            {
                int userId = Convert.ToInt32(Session["userId"]);
                Order order = db.Orders.Find(orderId);
                List<OrderViewModel> result =(from user in db.Users
                 join ord in db.Orders on user.Id equals userId
                 join od in db.Order_Products on ord.Id equals od.OrderId
                 join pd in db.Products on od.ProductId equals pd.Id
                 where od.OrderId==order.Id
                 select new OrderViewModel
                 {
                     OrderId=od.OrderId,
                     ProductName=pd.ProductName,
                     Quantity=od.Quantity,
                     FirstName = user.FirstName,
                     LastName=user.LastName,
                     Price=od.Price,
                     ShippingAddress=ord.ShippingAddress,
                     Note = ord.Note,
                     CreatedAt = ord.CreatedAt
                 }).ToList();
                return View(result);
            }
        }
        public ActionResult AllOrders()
        {
            int userId = Convert.ToInt32(Session["userId"]);
            using (ShopDBContext db = new ShopDBContext())
            {
                List<OrderViewModel> result = (from user in db.Users
                                               join ord in db.Orders on user.Id equals userId
                                               join od in db.Order_Products on ord.Id equals od.OrderId
                                               join pd in db.Products on od.ProductId equals pd.Id
                                               select new OrderViewModel
                                               {
                                                   OrderId = od.OrderId,
                                                   ProductName = pd.ProductName,
                                                   Quantity = od.Quantity,
                                                   FirstName = user.FirstName,
                                                   LastName = user.LastName,
                                                   Price = od.Price,
                                                   ShippingAddress = ord.ShippingAddress,
                                                   Note = ord.Note,
                                                   CreatedAt = ord.CreatedAt
                                               }).ToList();
                return View(result);
            }
        }
    }
}