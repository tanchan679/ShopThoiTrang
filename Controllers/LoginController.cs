using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.DAL;
using ShopThoiTrang.Models;
using System.Diagnostics;

namespace ShopThoiTrang.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserLogin temp)
        {
            Debug.WriteLine("Lay du lieu tu Form: " + temp.email + " - " + temp.pass);
            bool checkLogin = false;
            ConnectDatabase database = new ConnectDatabase();
            checkLogin = database.loginUser(temp);
            
            Session.Timeout = 6000;
            if (checkLogin == true)
            {
                Session["checkLogin"] = "True";
                Session["username"] = database.getNameByEmai(temp.email);
                Session["useremail"] = temp.email;
            }
            else Session["checkLogin"] = "False";
            Debug.WriteLine("Get name:"+database.getNameByEmai(temp.email));
            return checkLogin == true ? RedirectToAction("../") : RedirectToAction("./");
        }
    }
}