using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace web.Models
{
    public class LOAIQUYEN
    {
        public string conf = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public string ID { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public int them(string ma, string ten)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into LOAIQUYEN(MALOAIQUYEN,TenLoaiQuyen) values(N'" + ma + "',N'" + ten + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int update(string ma, string ten)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update LOAIQUYEN set TenLoaiQuyen =N'" + ten + "' where MALOAIQUYEN = '" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public List<LOAIQUYEN> getData()
        {
            List<LOAIQUYEN> listBH = new List<LOAIQUYEN>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from LOAIQUYEN", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAIQUYEN emp = new LOAIQUYEN();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ma = dr.GetValue(1).ToString();
                emp.Ten = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<LOAIQUYEN> getData(string ma)
        {
            List<LOAIQUYEN> listBH = new List<LOAIQUYEN>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from LOAIQUYEN where idloaiquyen ='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAIQUYEN emp = new LOAIQUYEN();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ma = dr.GetValue(1).ToString();
                emp.Ten = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
    }
}