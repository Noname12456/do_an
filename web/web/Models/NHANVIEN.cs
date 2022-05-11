using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace web.Models
{
    public class NHANVIEN
    {
        public string conf = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public string ID { get; set; }
        public string Ten { get; set; }
        public string Ho { get; set; }
        public string MK { get; set; }
        public string dc { get; set; }
        public string SDT { get; set; }
        public string tt { get; set; }
        public string email { get; set; }
        public string macn { get; set; }
        public string quyen { get; set; }
        public int them(string ma, string ten, string sdt, string dc, string mk, string cn, string email, string nguoitao, string quyen)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("select count(*) from Nhanvien where manv='" + ma + "'", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            Object kq = cmd2.ExecuteScalar();

            if (kq.Equals(0))
            {
                SqlCommand cmd = new SqlCommand("insert into NHANVIEN(manv,TENNV,sdt,dc,matkhau,macn,email,nguoitao,IDQUYEN) values(N'" + ma + "',N'" + ten + "','" + sdt + "',N'" + dc + "','" + mk + "','" + cn + "','" + email + "','" + nguoitao + "','" + quyen + "')", con);
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteNonQuery();
            }
            else
            {
                dr = -1;
            }
            con.Close();
            LOAIQUYENOFQUYEN clasquyen = new LOAIQUYENOFQUYEN();
            var menu = clasquyen.getData2(quyen);
            foreach (var item in menu)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into LOAIQUYENOFNHANVIEN(manv,IDLOAIQUYEN) values(N'" + ma + "',N'" + item.ID + "')", con);
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteNonQuery();
                con.Close();
            }
            return dr;
        }
        public int getData(string ma, string mk)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("select count(*) from NHANVIEN where manv='" + ma + "' and matkhau='" + mk + "' and disabled = 0", con);
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
        public List<NHANVIEN> getData()
        {
            List<NHANVIEN> listBH = new List<NHANVIEN>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from NHANVIEN", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NHANVIEN emp = new NHANVIEN();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                emp.SDT = dr.GetValue(4).ToString();
                emp.dc = dr.GetValue(2).ToString();
                emp.email = dr.GetValue(3).ToString();
                emp.macn = dr.GetValue(8).ToString();
                emp.tt = dr.GetValue(6).ToString();
                emp.quyen = dr.GetValue(9).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<NHANVIEN> getData(string ma)
        {
            List<NHANVIEN> listBH = new List<NHANVIEN>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from NHANVIEN where manv= '" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NHANVIEN emp = new NHANVIEN();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                emp.SDT = dr.GetValue(4).ToString();
                emp.dc = dr.GetValue(2).ToString();
                emp.email = dr.GetValue(3).ToString();
                emp.MK = dr.GetValue(7).ToString();
                emp.macn = dr.GetValue(8).ToString();
                emp.tt = dr.GetValue(6).ToString();
                emp.quyen = dr.GetValue(9).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public void update3(string ma)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update nhanvien set disabled=1 where manv='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
        }
        public int update(string ma, string ten, string sdt, string dc, string mk, string cn, string email, string nguoitao, string quyen)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update nhanvien set tennv= N'" + ten + "',sdt = '" + sdt + "',dc = N'" + dc + "',matkhau = N'" + mk + "',email = '" + email + "',nguoisua= '" + nguoitao + "',macn = '" + cn + "',IDQUYEN = '" + quyen + "' where manv='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand cmd3 = new SqlCommand("delete from LOAIQUYENOFNHANVIEN where manv='" + ma + "'", con);
            cmd3.CommandType = CommandType.Text;
            dr = cmd3.ExecuteNonQuery();
            con.Close();

            LOAIQUYENOFQUYEN clasquyen = new LOAIQUYENOFQUYEN();
            var menu = clasquyen.getData2(quyen);
            foreach (var item in menu)
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("insert into LOAIQUYENOFNHANVIEN(manv,IDLOAIQUYEN) values(N'" + ma + "',N'" + item.ID + "')", con);
                cmd2.CommandType = CommandType.Text;
                dr = cmd2.ExecuteNonQuery();
                con.Close();
            }

            return dr;
        }
        public void update4(string ma)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update nhanvien set disabled=0 where manv='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}