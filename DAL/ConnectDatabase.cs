using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Data.SqlClient;
using ShopThoiTrang.Models;

namespace ShopThoiTrang.DAL
{
    public class ConnectDatabase
    {
        public ConnectDatabase() {  }
        public SqlConnection getConnect()
        {
            String connectString = @"Data Source=DESKTOP-H3RT7J9;Initial Catalog=shopthoitrang;Integrated Security=True";
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(connectString);
            }
            catch (Exception e)
            {
                con = null;
            }
            return con;
        }
        public void dieConnect(SqlConnection conn)
        {
            conn.Close();
        }
        public void registerUser(UserRegister temp)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            String sql = "INSERT INTO nguoidung values('"+temp.name+"','" + temp.email + "','" + temp.pass + "','" + temp.phonenumber + "','" + temp.addadress + "')";
            SqlCommand ghi = new SqlCommand(sql, conn);
            ghi.ExecuteNonQuery();
            Debug.WriteLine(sql);

            dieConnect(conn);
        }
        public void addGioHang(GioHang temp)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            String sql = "INSERT INTO giohang values('" + temp.id_sanpham + "','" + temp.id_nguoidung + "','" + temp.soluong + "')";
            SqlCommand ghi = new SqlCommand(sql, conn);
            ghi.ExecuteNonQuery();
            Debug.WriteLine(sql);

            dieConnect(conn);
        }
        public void addLoaiSanPham(LoaiSanPham temp)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            String sql = "INSERT INTO loaisanpham values('" + temp.name + "')";
            SqlCommand ghi = new SqlCommand(sql, conn);
            ghi.ExecuteNonQuery();
            Debug.WriteLine(sql);

            dieConnect(conn);
        }
        public void addSanPham(SanPham temp)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            String sql = "INSERT INTO sanpham values(" +temp.phanloai +",'" + temp.name +"','"+ temp.hinhanh + "',"+ temp.giaban + ","+ temp.soluong + ",'"+ temp.kichthuoc + "','"+ temp.mota + "')";
            Debug.WriteLine(sql);
            SqlCommand ghi = new SqlCommand(sql, conn);
            ghi.ExecuteNonQuery();
           

            dieConnect(conn);
        }
        public void DeleteLoaiSanPhamByID(int id)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            String sql = "DELETE FROM loaisanpham where id = "+id;
            SqlCommand ghi = new SqlCommand(sql, conn);
            ghi.ExecuteNonQuery();
            Debug.WriteLine(sql);

            dieConnect(conn);
        }
        public void DeleteSanPhamByID(int id)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            String sql = "DELETE FROM sanpham where id = " + id;
            SqlCommand ghi = new SqlCommand(sql, conn);
            ghi.ExecuteNonQuery();
            Debug.WriteLine(sql);

            dieConnect(conn);
        }
        public bool loginUser(UserLogin temp)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            String sql = "SELECT email FROM nguoidung where email = '"+temp.email+"' and pass = '"+temp.pass+"'";
            SqlCommand laydata = new SqlCommand(sql, conn);
            SqlDataReader docdulieu = laydata.ExecuteReader();
            Debug.WriteLine(sql);
          
            while (docdulieu.Read()) return true;
            dieConnect(conn);
            return false;
        }
        public String getNameByEmai(String email)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            String sql = "SELECT ten FROM nguoidung where email = '" + email + "'";
            SqlCommand laydata = new SqlCommand(sql, conn);
            SqlDataReader docdulieu = laydata.ExecuteReader();
            Debug.WriteLine(sql);
            String name = "";
            while (docdulieu.Read()) name = docdulieu.GetString(0);
            dieConnect(conn);
            return name;
        }
        public int getIdByEmai(String email)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            String sql = "SELECT id FROM nguoidung where email = '" + email + "'";
            SqlCommand laydata = new SqlCommand(sql, conn);
            SqlDataReader docdulieu = laydata.ExecuteReader();
            Debug.WriteLine(sql);
            int id = 1;
            while (docdulieu.Read()) id = docdulieu.GetInt32(0);
            dieConnect(conn);
            return id;
        }
        public String getEmailByID(int id)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            String sql = "SELECT email FROM nguoidung where id = '" + id + "'";
            SqlCommand laydata = new SqlCommand(sql, conn);
            SqlDataReader docdulieu = laydata.ExecuteReader();
            Debug.WriteLine(sql);
            String email = "";
            while (docdulieu.Read()) email = docdulieu.GetString(0);
            dieConnect(conn);
            return email;
        }
        public UserInfo getUserInfo(String email)
        {
            UserInfo userInfo = new UserInfo();

            SqlConnection conn = getConnect();
            conn.Open();
            String sql = "SELECT * FROM nguoidung where email = '"+email+"'";
            SqlCommand laydata = new SqlCommand(sql, conn);
            SqlDataReader docdulieu = laydata.ExecuteReader();
            Debug.WriteLine(sql);

            while (docdulieu.Read())
            {
                String ten = docdulieu.GetString(1);
                String emaill = docdulieu.GetString(2);
                String sdt = docdulieu.GetString(4);
                String diachi = docdulieu.GetString(5);
                userInfo = new UserInfo(ten, email,sdt,diachi);
            }
            dieConnect(conn);

            return userInfo;
        }
        public String getPhanLoaiByID(int id)
        {
            SqlConnection conn = getConnect();
            conn.Open();
            String sql = "SELECT tenloai FROM loaisanpham where id = " +id;
            SqlCommand laydata = new SqlCommand(sql, conn);
            SqlDataReader docdulieu = laydata.ExecuteReader();
            String phanloai = "";
            while (docdulieu.Read()) phanloai = docdulieu.GetString(0);
            dieConnect(conn);
            return phanloai;
        }
        public List <SanPham> getListSanPham()
        {
            List <SanPham> sanpham= new List<SanPham>();


            SqlConnection conn = getConnect();
            conn.Open();
            String sql = "SELECT * FROM sanpham";
            SqlCommand laydata = new SqlCommand(sql, conn);
            SqlDataReader docdulieu = laydata.ExecuteReader();
            Debug.WriteLine(sql);

            while (docdulieu.Read()) {
                int id = docdulieu.GetInt32(0);
                int id_loaisanpham = docdulieu.GetInt32(1);
                String phanloai = getPhanLoaiByID(id_loaisanpham);
                String name = docdulieu.GetString(2);
                String hinhanh = docdulieu.GetString(3);
                int giaban = docdulieu.GetInt32(4);
                int soluong = docdulieu.GetInt32(5);
                String kichthuoc = docdulieu.GetString(6);
                String mota = docdulieu.GetString(7);
                sanpham.Add(new SanPham(id, name, phanloai, hinhanh, giaban, soluong, kichthuoc, mota));
            }
            dieConnect(conn);


            return sanpham;
        }
        public void deleteItemCartById(int id)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            String sql = "DELETE giohang where id = " + id;
            SqlCommand ghi = new SqlCommand(sql, conn);
            ghi.ExecuteNonQuery();
            Debug.WriteLine(sql);

            dieConnect(conn);
        }
        public List<SanPham> getListCart(int id_user)
        {
            List<SanPham> sanpham = new List<SanPham>();


            SqlConnection conn = getConnect();
            conn.Open();
            String sql = "Select * from sanpham, giohang where sanpham.id = giohang.id_sanpham and id_nguoidung = "+id_user;
            SqlCommand laydata = new SqlCommand(sql, conn);
            SqlDataReader docdulieu = laydata.ExecuteReader();
            Debug.WriteLine(sql);

            while (docdulieu.Read())
            {
                int id = docdulieu.GetInt32(8);
                int id_loaisanpham = docdulieu.GetInt32(1);
                String phanloai = "TEMP";
                String name = docdulieu.GetString(2);
                String hinhanh = docdulieu.GetString(3);
                int giaban = docdulieu.GetInt32(4);
                int soluong = docdulieu.GetInt32(11);
                String kichthuoc = docdulieu.GetString(6);
                String mota = docdulieu.GetString(7);
                sanpham.Add(new SanPham(id, name, phanloai, hinhanh, giaban, soluong, kichthuoc, mota));
            }
            dieConnect(conn);


            return sanpham;
        }
        public SanPham getSanPhamByID(int id)
        {
            SanPham sanpham = new SanPham();


            SqlConnection conn = getConnect();
            conn.Open();
            String sql = "SELECT * FROM sanpham where id = "+id;
            Debug.WriteLine(sql);
            SqlCommand laydata = new SqlCommand(sql, conn);
            SqlDataReader docdulieu = laydata.ExecuteReader();
          

            while (docdulieu.Read())
            {
                int id_loaisanpham = docdulieu.GetInt32(1);
                String phanloai = "TEMP";
                String name = docdulieu.GetString(2);
                String hinhanh = docdulieu.GetString(3);
                int giaban = docdulieu.GetInt32(4);
                int soluong = docdulieu.GetInt32(5);
                String kichthuoc = docdulieu.GetString(6);
                String mota = docdulieu.GetString(7);
                sanpham = new SanPham(id, name, phanloai, hinhanh, giaban, soluong, kichthuoc, mota);
                break;
            }
            dieConnect(conn);


            return sanpham;
        }
        public String checkLoaiSanPhamInSanPhamById(int id)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            String sql = "SELECT ten FROM sanpham where id_loaisanpham = " + id ;
            SqlCommand laydata = new SqlCommand(sql, conn);
            SqlDataReader docdulieu = laydata.ExecuteReader();
            Debug.WriteLine(sql);
            String name = "";
            while (docdulieu.Read()) name = docdulieu.GetString(0);
            dieConnect(conn);
            return name;
        }
        public String checkSanPhamInGioHangById(int id)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            String sql = "SELECT id_sanpham FROM giohang where id_sanpham = " + id;
            SqlCommand laydata = new SqlCommand(sql, conn);
            Debug.WriteLine(sql);
            SqlDataReader docdulieu = laydata.ExecuteReader();
        
            String name = "";
            while (docdulieu.Read()) name = "hfghghghfj";
            dieConnect(conn);
            return name;
        }
        public String checkLoaiSanPhamByID(int id)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            String sql = "SELECT tenloai FROM loaisanpham where id = " + id;
            SqlCommand laydata = new SqlCommand(sql, conn);
            Debug.WriteLine(sql);
            SqlDataReader docdulieu = laydata.ExecuteReader();

            String name = "";
            while (docdulieu.Read()) name = docdulieu.GetString(0);
            dieConnect(conn);
            return name;
        }
        public List<LoaiSanPham> getListLoaiSanPham()
        {
            List<LoaiSanPham> lsanpham = new List<LoaiSanPham>();


            SqlConnection conn = getConnect();
            conn.Open();
            String sql = "Select * from loaisanpham ";
            SqlCommand laydata = new SqlCommand(sql, conn);
            SqlDataReader docdulieu = laydata.ExecuteReader();
            Debug.WriteLine(sql);

            while (docdulieu.Read())
            {
                int id = docdulieu.GetInt32(0);
                
                String loasanpham = docdulieu.GetString(1);
                lsanpham.Add(new LoaiSanPham(id, loasanpham));
            }
            dieConnect(conn);


            return lsanpham;
        }
    }
}