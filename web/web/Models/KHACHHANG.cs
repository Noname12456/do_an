using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace web.Models
{
    public class KHACHHANG
    {
        public string conf = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int ID { get; set; }
        public string Ten { get; set; }
        public string Ho { get; set; }
        public string MK { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public int DiemTL { get; set; }
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
        public int update(string email, string mk)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("update KHACHHANG set matkhau = '" + mk + "' where email= '" + email + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;

        }
        public int updateDiem1(string email)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("update KHACHHANG set DIEMTL = 0 where email= '" + email + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;

        }
        public int updateDiem1(string email,int tong)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("update KHACHHANG set DIEMTL = DIEMTL - " + tong + " where email= '" + email + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;

        }
        public int updateDiem(string email,float diem)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("update KHACHHANG set DIEMTL = DIEMTL + " + (int) diem + " where email= '" + email + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;

        }
        public int updateDiemAD(string email, float diem)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("update KHACHHANG set DIEMTL = DIEMTL + " + (int)diem + " where makh= '" + email + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;

        }
        public int updateDiemAD1(string email)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("update KHACHHANG set DIEMTL = 0 where makh= '" + email + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            dr = cmd.ExecuteNonQuery();
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
                emp.DiemTL = int.Parse(dr.GetValue(8).ToString());
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<KHACHHANG> getDataAdminKH(string kh)
        {
            List<KHACHHANG> listBH = new List<KHACHHANG>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from KHACHHANG where email = '" + kh + "' or sdt = '" + kh + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                KHACHHANG emp = new KHACHHANG();
                emp.ID = Convert.ToInt32(dr.GetValue(0).ToString());
                emp.Ho = dr.GetValue(1).ToString();
                emp.Ten = dr.GetValue(2).ToString();
                emp.DiemTL = int.Parse(dr.GetValue(8).ToString());
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int getDataTL(string email)
        {
            int diem = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from KHACHHANG where email='" + email + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                diem = int.Parse(dr.GetValue(8).ToString());
            }
            con.Close();
            return diem;
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