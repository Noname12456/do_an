using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class SANPHAMHINHANH
    {
        public string conf = "Data Source=LAPTOP-G07FAD75;Initial Catalog=QL_NhaSach;User ID=sa";
        public string ID { get; set; }
        public string MASP { get; set; }
        public string HINH { get; set; }
        public string HINH2 { get; set; }
        public int disabled { get; set; }
        public HttpPostedFileWrapper file { get; set; }
        public List<SANPHAMHINHANH> getData(string masp)
        {
            List<SANPHAMHINHANH> listBH = new List<SANPHAMHINHANH>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select Top 1 * from SANPHAMHINHANH where disabled=0  and masp='" + masp + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAMHINHANH emp = new SANPHAMHINHANH();
                emp.ID = dr.GetValue(0).ToString();
                emp.HINH = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<SANPHAMHINHANH> getData2(string masp)
        {
            List<SANPHAMHINHANH> listBH = new List<SANPHAMHINHANH>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from SANPHAMHINHANH where masp='" + masp + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAMHINHANH emp = new SANPHAMHINHANH();
                emp.ID = dr.GetValue(0).ToString();
                emp.MASP = dr.GetValue(1).ToString();
                emp.HINH = dr.GetValue(2).ToString();
                emp.disabled = int.Parse(dr.GetValue(3).ToString());
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int Delete(int masp)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update SANPHAMHINHANH set disabled = 1 where mahinh =" + masp, con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int PHUCHOI(int masp)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update SANPHAMHINHANH set disabled = 0 where mahinh =" + masp, con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
    }
}