using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Models
{
    public class SanPham
    {
        public int id;
        public String name;
        public String phanloai;
        public String hinhanh;
        public int giaban;
        public int soluong;
        public String kichthuoc;
        public String mota;
        public SanPham() { }
        public SanPham(int id, String name, String phanloai, String hinhanh, int giaban, int soluong, String kichthuoc, String mota) {
            this.id = id;
            this.name = name;
            this.phanloai = phanloai;
            this.hinhanh = hinhanh;
            this.giaban = giaban;
            this.soluong = soluong;
            this.kichthuoc = kichthuoc;
            this.mota = mota;
        }
        public int Id { get => this.id; set => this.id = value; }
        public String Name { get => this.name; set => this.name = value; }
        public String Phanloai { get => this.phanloai; set => this.phanloai = value; }
        public String Hinhanh { get => this.hinhanh; set => this.hinhanh = value; }
        public int Giaban { get => this.giaban; set => this.giaban = value; }
        public int Soluong { get => this.soluong; set => this.soluong = value; }
        public String Kichthuoc { get => this.kichthuoc; set => this.kichthuoc = value; }
        public String Mota { get => this.mota; set => this.mota = value; }

    }
}