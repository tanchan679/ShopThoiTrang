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
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserLogin temp)
        {
            if(temp.email == "tanchan679@gmail.com" && temp.pass == "admin")
            {
                Session["loginadmin"] = "1";
            }
            return RedirectToAction("");
        }
        public ActionResult QuanLySanPham()
        {
            List<SanPham> sanpham = new List<SanPham>();
            ConnectDatabase database = new ConnectDatabase();
            sanpham = database.getListSanPham();
            return View(sanpham);
        }
        [HttpPost]
        public ActionResult QuanLySanPham(LoaiSanPham temp)
        {
            Debug.WriteLine("Du lieu dau vao: " + temp.Id);
            ConnectDatabase dtb = new ConnectDatabase();
            if (dtb.checkSanPhamInGioHangById(temp.Id).Length == 0)
            {
                new ConnectDatabase().DeleteSanPhamByID(temp.Id);
            }
            else
            {
                Session["checkerr"] = "error";
            }

            return RedirectToAction("/QuanLySanPham");
        }
        public ActionResult QuanLyLoaiSanPham()
        {
            ConnectDatabase database = new ConnectDatabase();
            return View(database.getListLoaiSanPham());
        }
        [HttpPost]
        public ActionResult QuanLyLoaiSanPham(LoaiSanPham temp)
        {
            Debug.WriteLine("Du lieu dau vao: " + temp.Id);
            ConnectDatabase dtb = new ConnectDatabase();
            if(dtb.checkLoaiSanPhamInSanPhamById(temp.Id).Length == 0)
            {
                new ConnectDatabase().DeleteLoaiSanPhamByID(temp.Id);
            }
            else
            {
                Session["checkerr"] = "error";
            }
            
            return RedirectToAction("/QuanLyLoaiSanPham");
        }
        public ActionResult ThemMoiSanPham()
        {
            return View();
        }
        public ActionResult ThemMoiLoaiSanPham()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoiSanPham(SanPham temp)
        {
            int loi = 0;
            Debug.WriteLine("Data them: " + temp.name);
            if (new ConnectDatabase().checkLoaiSanPhamByID(int.Parse(temp.phanloai)).Length > 0)
            {
                loi = 0;
                new ConnectDatabase().addSanPham(temp);
            }
            else
            {
                loi = 1;
                Session["checkerr"] = "error";
            }
            return loi==0?RedirectToAction("./QuanLySanPham"): RedirectToAction("./ThemMoiSanPham");
        }
        [HttpPost]
        public ActionResult ThemMoiLoaiSanPham(LoaiSanPham temp)
        {
            Debug.WriteLine("Data them: " + temp.name);
            new ConnectDatabase().addLoaiSanPham(temp);
            return RedirectToAction("./QuanLyLoaiSanPham");
        }

    }
}