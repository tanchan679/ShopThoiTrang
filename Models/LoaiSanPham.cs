using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Models
{
    public class LoaiSanPham
    {
        public int id;
        public String name;

        public LoaiSanPham() { }
        public LoaiSanPham(int id, String name) {
            this.id = id;
            this.name = name;
        }
        public int Id{get=>this.id; set=>this.id= value;}
        public String Name { get => this.name; set => this.name = value; }
    }
}