using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CookiesShop.Models;
using System.Data;
using System.Data.SqlClient;

namespace DapperProject.Controllers
{
    public class AddToCartController : Controller
    {
        // GET: AddToCart
        //Add to cart list
        [HttpPost]
        public ActionResult Add(int Id=0)
        {
            Product mo = null;
            int count = 0;
            using (ShopDBContext db=new ShopDBContext())
            {
                mo = db.Products.Find(Id);
            }
            if (Session["cart"] == null)
            {
                List<Product> li = new List<Product>();
                mo.Quantity = 1;
                li.Add(mo);
                Session["cart"] = li;
                ViewBag.cart = li.Count();


                Session["count"] = 1;
                count = Convert.ToInt32(Session["count"]);


            }
            else
            {
                List<Product> li = (List<Product>)Session["cart"];
                var alreadyExist = li.Where(x=>x.Id==Id).FirstOrDefault();
                if (alreadyExist != null)
                {
                    alreadyExist.Quantity += 1;
                    alreadyExist.Price = alreadyExist.Quantity * mo.Price;
                    Remove(alreadyExist.Id);
                    mo = alreadyExist;
                }
                else
                {
                    mo.Quantity = 1;
                }
                li.Add(mo);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                count = Convert.ToInt32(Session["count"]);

            }
            return Json(count);


        }
        //Items dsiplay that have been added into the cart
        public ActionResult Myorder()
        {

            return View((List<Product>)Session["cart"]);

        }
        //Remove item from the cart
        public ActionResult Remove(int Id=0)
        {
            List<Product> li = (List<Product>)Session["cart"];
            li.RemoveAll(x => x.Id == Id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Myorder", "AddToCart");
            //return View();
        }
    }
}