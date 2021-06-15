using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;
using ShopThoiTrang.DAL;
using System.Diagnostics;
namespace ShopThoiTrang.Controllers
{
    public class UserController : Controller
    {
        private UserInfo userinfo= new UserInfo();
        // GET: User
        public ActionResult Index()
        {
         
            ConnectDatabase database = new ConnectDatabase();
            if (Session["useremail"]!=null)
            {
                String email = Session["useremail"].ToString();
                Debug.WriteLine(email);
                userinfo = database.getUserInfo(email);
            }
            return View(userinfo);
        }
        [HttpPost]
        public ActionResult Index(UserInfo temp)
        {
            Session.Contents.Remove("useremail");
            Session.Contents.Remove("username");
            return RedirectToAction("../");
        }
        public ActionResult Cart()
        {
            ConnectDatabase database = new ConnectDatabase();
            String email = Session["useremail"].ToString();
            int idUser = database.getIdByEmai(email);
            return View(database.getListCart(idUser));
        }
        [HttpPost]
        public ActionResult Cart(GioHang temp)
        {
            Debug.WriteLine("ID XOA"+temp.id);
            new ConnectDatabase().deleteItemCartById(temp.id);
            return RedirectToAction("/Cart");
        }
        public ActionResult Payment()
        {
            return View();
        }
    }
}