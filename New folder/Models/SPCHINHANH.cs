using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace web.Models
{
    public class SPCHINHANH
    {
        public string conf = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public string MASP { get; set; }
        public string TENSP { get; set; }
        public string SLTON { get; set; }
        public string DG { get; set; }
        public List<SPCHINHANH> getData2(string ma)
        {
            List<SPCHINHANH> listBH = new List<SPCHINHANH>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select sanpham.masp,tensp,sanphamcn.slton from Sanpham,SANPHAMCN where sanpham.masp = sanphamcn.masp and sanpham.disabled = 0 and sanphamcn.disabled = 0 and SANPHAMCN.macn='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SPCHINHANH emp = new SPCHINHANH();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.SLTON = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int getData(string ma,string macn,string sl)
        {
            List<SPCHINHANH> listBH = new List<SPCHINHANH>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select Count(*) from Sanpham,SANPHAMCN where sanpham.masp = sanphamcn.masp and sanpham.disabled = 0 and sanphamcn.disabled = 0 and SANPHAMCN.masp='" + ma + "' and SANPHAMCN.macn = '" + macn + "' and SANPHAMCN.SLTON >= '" + sl + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.CommandType = CommandType.Text;
            Object kq = cmd.ExecuteScalar();
            con.Close();
            return int.Parse(kq.ToString());
        }
        public List<SPCHINHANH> getData3(string ma)
        {
            List<SPCHINHANH> listBH = new List<SPCHINHANH>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select sanpham.masp,tensp,sanphamcn.slton  from Sanpham,SANPHAMCN where sanpham.masp = sanphamcn.masp and sanpham.disabled = 0 and sanphamcn.disabled = 1 and SANPHAMCN.macn='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SPCHINHANH emp = new SPCHINHANH();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.SLTON = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<SPCHINHANH> getData4(string ma)
        {
            List<SPCHINHANH> listBH = new List<SPCHINHANH>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select sanpham.masp,tensp  from Sanpham where masp not in (select masp from SANPHAMCN where macn='" + ma + "')", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SPCHINHANH emp = new SPCHINHANH();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int them(string ma, string macn, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into SANPHAMCN(macn,masp,NGUOITAO) values(N'" + macn + "','" + ma + "',N'" + nguoitao + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int update(string ma, string macn, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update SANPHAMCN set disabled = 0, nguoisua = '" + nguoitao + "' where MACN='" + macn + "' and masp ='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int update2(string ma, string macn, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update SANPHAMCN set disabled = 1, nguoisua = '" + nguoitao + "' where MACN='" + macn + "' and masp ='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public List<SPCHINHANH> getData2(string ten, string macn)
        {
            List<SPCHINHANH> listBH = new List<SPCHINHANH>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select sanpham.masp,tensp,sanphamcn.slton,GIABAN from Sanpham,SANPHAMCN where sanpham.masp = sanphamcn.masp and sanpham.disabled = 0 and sanphamcn.disabled = 0 and SANPHAMCN.macn='" + macn + "' and tensp like N'%" + ten + "%' or SANPHAMCN.masp = N'%" + ten + "%' ", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SPCHINHANH emp = new SPCHINHANH();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.SLTON = dr.GetValue(2).ToString();
                emp.DG = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int getDataSL(string ten, string macn)
        {
            int sl = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select sanpham.masp,tensp,sanphamcn.slton from Sanpham,SANPHAMCN where sanpham.masp = sanphamcn.masp and sanpham.disabled = 0 and sanphamcn.disabled = 0 and SANPHAMCN.macn='" + macn + "' and tensp like N'%" + ten + "%' or SANPHAMCN.masp like N'%" + ten + "%' ", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()){
                sl = int.Parse(dr.GetValue(2).ToString());
            }
            con.Close();
            return sl;
        }
        public void updateSLDH(string ma, int SL, string macn)
        {
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd3 = new SqlCommand("update SANPHAMCN set SLTON= SLTON - " + SL + " where masp='" + ma + "' and macn= '" + macn + "'", con);
            cmd3.CommandType = CommandType.Text;
            cmd3.ExecuteNonQuery();
            con.Close();
        }
        public void updateSLDH2(string ma, int SL, string macn)
        {
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd3 = new SqlCommand("update SANPHAMCN set SLTON= SLTON + " + SL + " where masp='" + ma + "' and macn= '" + macn + "'", con);
            cmd3.CommandType = CommandType.Text;
            cmd3.ExecuteNonQuery();
            con.Close();
        }
    }
}