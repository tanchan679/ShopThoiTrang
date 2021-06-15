using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Models
{
    public class GioHang
    {
        public int id;
        public int id_nguoidung;
        public int id_sanpham;
        public int soluong;

        public GioHang() { }
        public GioHang(int id, int id_nguoidung,int id_sanpham,int soluong) {
            this.id = id;
            this.id_nguoidung = id_nguoidung;
            this.id_sanpham = id_sanpham;
            this.soluong = soluong;
        }
        public int Id { get => this.id; set => this.id = value; }
        public int Id_nguoidung { get => this.id_nguoidung; set => this.id_nguoidung = value; }
        public int Id_sanpham { get => this.id_sanpham; set => this.id_sanpham = value; }
        public int Soluong { get => this.soluong; set => this.soluong = value; }
    }
}