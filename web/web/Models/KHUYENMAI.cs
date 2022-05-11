using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class KHUYENMAI
    {
        string conf = "Data Source=LAPTOP-G07FAD75;Initial Catalog=QL_NhaSach;User ID=sa";
        public string ID { get; set; }
        public string ST { get; set; }
        public string NGAYBD { get; set; }
        public string NGAYKT { get; set; }
        public string HINHTHUCKM { get; set; }
        public string DK { get; set; }
        public string disabled { get; set; }
        public List<KHUYENMAI> getData(string sr)
        {
            List<KHUYENMAI> listBH = new List<KHUYENMAI>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from KHUYENMAI where makhm='" + sr + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                KHUYENMAI emp = new KHUYENMAI();
                emp.ID = dr.GetValue(0).ToString();
                emp.ST = dr.GetValue(1).ToString();
                emp.NGAYBD = dr.GetValue(2).ToString();
                emp.NGAYKT = dr.GetValue(3).ToString();
                emp.DK = dr.GetValue(4).ToString();
                emp.HINHTHUCKM = dr.GetValue(5).ToString();
                emp.disabled = dr.GetValue(10).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int getData6(string sr)
        {
            List<KHUYENMAI> listBH = new List<KHUYENMAI>();
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from KHUYENMAI where makhm='" + sr + "'", con);
            cmd.CommandType = CommandType.Text;
            Object kq = cmd.ExecuteScalar();
            con.Close();
            return int.Parse(kq.ToString());
        }
        public List<KHUYENMAI> getData()
        {
            List<KHUYENMAI> listBH = new List<KHUYENMAI>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from KHUYENMAI", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                KHUYENMAI emp = new KHUYENMAI();
                emp.ID = dr.GetValue(0).ToString();
                emp.ST = dr.GetValue(1).ToString();
                emp.NGAYBD = dr.GetValue(2).ToString();
                emp.NGAYKT = dr.GetValue(3).ToString();
                emp.DK = dr.GetValue(4).ToString();
                emp.HINHTHUCKM = dr.GetValue(5).ToString();
                emp.disabled = dr.GetValue(10).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int update3(string ma)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update KHUYENMAI set disabled = 1 where MAKHM='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int update4(string ma)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update KHUYENMAI set disabled = 0 where MAKHM='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int them(string ma, string gia, string dk,string hk,string ngaybd,string ngaykt, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into KHUYENMAI(MAKHM,GIATIEN,DIEUKIEN,HINHTHUCKM,NGAYBD,NGAYKET,NGUOITAO) values(N'" + ma + "',N'" + gia + "','" + dk + "','"+hk+"','"+ngaybd+"','"+ngaykt+"',N'" + nguoitao + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int updateKM(string ma, string gia, string dk, string hk, string ngaybd, string ngaykt, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update KHUYENMAI set GIATIEN = N'" + gia + "',DIEUKIEN= N'" + dk + "',HINHTHUCKM = '" + hk + "',NGAYBD = '" + ngaybd + "',NGAYKET = '" + ngaykt + "' where MAKHM='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
    }
}