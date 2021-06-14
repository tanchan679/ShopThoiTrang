using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using ShopThoiTrang.Models;

namespace ShopThoiTrang.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            Debug.WriteLine("Khoi chay");
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserRegister temp)
        {
            Debug.WriteLine("DATA POST: "+temp.name +" - " + temp.email + " - " + temp.pass + " - " + temp.passConfirm + " - " + temp.phonenumber + " - "+temp.addadress);
            return 1==1?RedirectToAction("./"):RedirectToAction("../");
        }
    }
}