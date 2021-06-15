using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;
using ShopThoiTrang.DAL;

namespace ShopThoiTrang.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<SanPham> sanpham = new List<SanPham>();
            ConnectDatabase database = new ConnectDatabase();
            sanpham = database.getListSanPham();
            return View(sanpham);
        }

        public ActionResult LazyTeam()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}