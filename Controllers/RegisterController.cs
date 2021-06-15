using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using ShopThoiTrang.Models;
using ShopThoiTrang.DAL;

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
            bool check = true;
            ConnectDatabase databae = new ConnectDatabase();
            Debug.WriteLine(temp.pass+  " --- " + temp.passConfirm);
            if (temp.pass == temp.passConfirm)
            {
                Debug.WriteLine("Bang nhau");
                if (databae.getNameByEmai(temp.email).Length == 0)
                {
                    databae.registerUser(temp);
                    Session["username"] = databae.getNameByEmai(temp.email);
                }
                else check = false;
            }
            else
            {
                Debug.WriteLine("Khong Bang nhau");
                check = false;
            }
           
            return check==true?RedirectToAction("../"):RedirectToAction("./");
        }
    }
}