using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class KHACHHANG
    {
        string conf = "Data Source=KID;Initial Catalog=QL_NhaSach;User ID=sa";
        public int ID { get; set; }
        public string Ten { get; set; }
        public string Ho { get; set; }
        public string MK { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public int them(string ho, string ten, string sdt, string email, string mk)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("select count(*) from KHACHHANG where email='" + email + "'", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            Object kq = cmd2.ExecuteScalar();

            if (kq.Equals(0))
            {
                SqlCommand cmd = new SqlCommand("insert into KHACHHANG(HOKH,TENKH,EMAIL,MATKHAU,SDT) values(N'" + ho + "',N'" + ten + "','" + email + "',N'" + mk + "','" + SDT + "')", con);
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteNonQuery();
            }
            else
            {
                dr = -1;
            }
            con.Close();
            return dr;

        }
        public List<KHACHHANG> getData(string email)
        {
            List<KHACHHANG> listBH = new List<KHACHHANG>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from KHACHHANG where email='" + email + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                KHACHHANG emp = new KHACHHANG();
                emp.ID = Convert.ToInt32(dr.GetValue(0).ToString());
                emp.Ho = dr.GetValue(1).ToString();
                emp.Ten = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<KHACHHANG> getData()
        {
            List<KHACHHANG> listBH = new List<KHACHHANG>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from KHACHHANG", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                KHACHHANG emp = new KHACHHANG();
                emp.ID = Convert.ToInt32(dr.GetValue(0).ToString());
                emp.Ho = dr.GetValue(1).ToString();
                emp.Ten = dr.GetValue(2).ToString();
                emp.Email = dr.GetValue(4).ToString();
                emp.SDT = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int getData(string email, string mk)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("select count(*) from KHACHHANG where email='" + email + "' and matkhau='" + mk + "'", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            Object kq = cmd2.ExecuteScalar();

            if (kq.Equals(0))
            {
                dr = 0;
            }
            else
            {
                dr = 1;
            }
            con.Close();
            return dr;
        }
    }
}