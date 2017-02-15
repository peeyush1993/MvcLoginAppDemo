using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLoginAppDemo.Models;

namespace MvcLoginAppDemo.Controllers
{
    [RoutePrefix("admin")]
    
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(loginModel objUser)
        {
            DB_Entities db = new DB_Entities();
            if (ModelState.IsValid)
            {
 
        
                    var obj = db.tbl_AdminLogin.Any(a => a.UserName == objUser.UsernName && a.PassWord == objUser.Password);
                    if (obj)
                    {

                        Session["UserName"] = (from user in db.tbl_AdminLogin where user.UserName == objUser.UsernName && user.PassWord==objUser.Password
                                               select user.FullName).First();
                        return RedirectToAction("UserDashBoard");
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "UserName or Password is incorrect");
                    }
 
            }
            return View(objUser);
        }
        [HttpGet]
       
        public ActionResult UserDashBoard()
        {
            if (Session["UserName"] != null)
            {
                ProductDetailModel prod = new ProductDetailModel();
                prod.listofLogin = ProductData();
                return View(prod);
            }
            else
            {
                return RedirectToAction("Login","Home");
            }

        }
        public List<loginModel> ProductData()
        {
            List<loginModel> objProduct = new List<loginModel>();
            DB_Entities objDemoEntities = new DB_Entities();
            var ProductItem = from data in objDemoEntities.tbl_AdminLogin select data;
            foreach (var item in ProductItem)
            {
                    objProduct.Add(new loginModel {
                    UsernName = item.UserName,
                    Password = item.PassWord
                });
            }
            return objProduct;
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            string xx = "peeyush";
            string cc = "this is sejf";

            return RedirectToAction("Login", "Home");
        }

    }
}