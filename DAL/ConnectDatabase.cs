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
                String phanloai = "TEMP";
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
    }
}