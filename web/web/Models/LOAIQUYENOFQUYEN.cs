using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace web.Models
{
    public class LOAIQUYENOFQUYEN
    {
        public string conf = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public string ID { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public List<LOAIQUYENOFQUYEN> getData2(string ma)
        {
            List<LOAIQUYENOFQUYEN> listBH = new List<LOAIQUYENOFQUYEN>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("Select LOAIQUYEN.IDLOAIQUYEN,LOAIQUYEN.MALOAIQUYEN,LOAIQUYEN.TenLoaiQuyen from LOAIQUYENOFQUYEN,QUYEN,LOAIQUYEN where LOAIQUYENOFQUYEN.IDLOAIQUYEN=loaiquyen.IDLOAIQUYEN and quyen.IDQUYEN = LOAIQUYENOFQUYEN.IDQUYEN and LOAIQUYENOFQUYEN.disabled = 0 and LOAIQUYENOFQUYEN.IDQUYEN = '" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAIQUYENOFQUYEN emp = new LOAIQUYENOFQUYEN();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ma = dr.GetValue(1).ToString();
                emp.Ten = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<LOAIQUYENOFQUYEN> getData3(string ma)
        {
            List<LOAIQUYENOFQUYEN> listBH = new List<LOAIQUYENOFQUYEN>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("Select LOAIQUYEN.IDLOAIQUYEN,LOAIQUYEN.MALOAIQUYEN,LOAIQUYEN.TenLoaiQuyen from LOAIQUYENOFQUYEN,QUYEN,LOAIQUYEN where LOAIQUYENOFQUYEN.IDLOAIQUYEN=loaiquyen.IDLOAIQUYEN and quyen.IDQUYEN = LOAIQUYENOFQUYEN.IDQUYEN and LOAIQUYENOFQUYEN.disabled = 1 and LOAIQUYENOFQUYEN.IDQUYEN = '" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAIQUYENOFQUYEN emp = new LOAIQUYENOFQUYEN();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ma = dr.GetValue(1).ToString();
                emp.Ten = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<LOAIQUYENOFQUYEN> getData4(string ma)
        {
            List<LOAIQUYENOFQUYEN> listBH = new List<LOAIQUYENOFQUYEN>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select IDLOAIQUYEN,MALOAIQUYEN,TenLoaiQuyen from LOAIQUYEN where IDLOAIQUYEN not in (select IDLOAIQUYEN from LOAIQUYENOFQUYEN where IDQUYEN='" + ma + "')", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAIQUYENOFQUYEN emp = new LOAIQUYENOFQUYEN();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ma = dr.GetValue(1).ToString();
                emp.Ten = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int them(int maloaiquyen, string maquyen)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into LOAIQUYENOFQUYEN(IDQUYEN,IDLOAIQUYEN) values(N'" + maquyen + "','" + maloaiquyen + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            SqlCommand cmd3 = new SqlCommand("select MANV from NHANVIEN where IDQUYEN = '" + maquyen + "'", con);
            cmd3.CommandType = CommandType.Text;
            con.Close();
            SqlDataReader dr2 = cmd3.ExecuteReader();
            while (dr2.Read())
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("insert into LOAIQUYENOFNHANVIEN(MANV,IDLOAIQUYEN) values(N'" + dr2.GetValue(0).ToString() + "','" + maloaiquyen + "')", con);
                cmd2.CommandType = CommandType.Text;
                dr = cmd2.ExecuteNonQuery();
                con.Close();
            }
            return dr;
        }
        public int update(int maloaiquyen, string maquyen)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update LOAIQUYENOFQUYEN set disabled = 0 where IDQUYEN='" + maquyen + "' and IDLOAIQUYEN ='" + maloaiquyen + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            SqlCommand cmd2 = new SqlCommand("update LOAIQUYENOFNHANVIEN set LOAIQUYENOFNHANVIEN.disabled = 0  from NHANVIEN where  IDQUYEN='" + maquyen + "' and LOAIQUYENOFNHANVIEN.IDLOAIQUYEN ='" + maloaiquyen + "' and LOAIQUYENOFNHANVIEN.manv=nhanvien.manv", con);
            cmd2.CommandType = CommandType.Text;
            dr = cmd2.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int update2(int maloaiquyen, string maquyen)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update LOAIQUYENOFQUYEN set disabled = 1 where IDQUYEN='" + maquyen + "' and IDLOAIQUYEN ='" + maloaiquyen + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            SqlCommand cmd2 = new SqlCommand("update LOAIQUYENOFNHANVIEN set LOAIQUYENOFNHANVIEN.disabled = 1  from NHANVIEN where  IDQUYEN='" + maquyen + "' and LOAIQUYENOFNHANVIEN.IDLOAIQUYEN ='" + maloaiquyen + "' and LOAIQUYENOFNHANVIEN.manv=nhanvien.manv", con);
            cmd2.CommandType = CommandType.Text;
            dr = cmd2.ExecuteNonQuery();
            con.Close();
            return dr;
        }
    }
}