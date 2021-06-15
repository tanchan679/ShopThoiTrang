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
    public class SingleController : Controller
    {
        // GET: Single
        public ActionResult Index()
        {
            SanPham sanpham = new SanPham();
            ConnectDatabase database = new ConnectDatabase();
            int id = int.Parse(Session["idsingle"].ToString());
          
            sanpham = database.getSanPhamByID(id);
            return View(sanpham);

        }

        [HttpPost]
        public ActionResult Index(SanPham temp)
        {
            ConnectDatabase database = new ConnectDatabase();
            String email = Session["useremail"].ToString();
            GioHang addcCart = new GioHang();
            addcCart.id = 0;
            addcCart.soluong = temp.soluong;
            addcCart.id_sanpham = temp.id;
            addcCart.id_nguoidung = database.getIdByEmai(email);

            database.addGioHang(addcCart);
            
           return RedirectToAction("");
        }
    }
}