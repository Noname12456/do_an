using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using web.Models;
namespace web.Models
{
    public class LOAIMATHANG
    {
        public string conf = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public string ID { get; set; }
        public string Ten { get; set; }
        public string MaMH { get; set; }
        public List<LOAIMATHANG> getData()
        {
            List<LOAIMATHANG> listBH = new List<LOAIMATHANG>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from LOAIMATHANG where disabled=0", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAIMATHANG emp = new LOAIMATHANG();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<LOAIMATHANG> getData(string ma)
        {
            List<LOAIMATHANG> listBH = new List<LOAIMATHANG>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select MATHANG.* from LOAIMATHANG,MATHANG where  LOAIMATHANG.MAMH = MATHANG.MAMH and LOAIMATHANG.MALOAI='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAIMATHANG emp = new LOAIMATHANG();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int getData2(string ma)
        {
            List<LOAIMATHANG> listBH = new List<LOAIMATHANG>();
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Count(*) from LOAIMATHANG where LOAIMATHANG.MALOAI='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            Object kq = cmd.ExecuteScalar();
            con.Close();
            return int.Parse(kq.ToString());
        }
        public List<LOAIMATHANG> getData3(string ma)
        {
            List<LOAIMATHANG> listBH = new List<LOAIMATHANG>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select LOAIMATHANG.* from LOAIMATHANG where LOAIMATHANG.MALOAI='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAIMATHANG emp = new LOAIMATHANG();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                emp.MaMH = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int themLoaiMH(string ma, string ten, string mh, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into LOAIMATHANG(MALOAI,TENLOAI,MAMH,NGUOITAO) values(N'" + ma + "',N'" + ten + "','"+mh+"',N'" + nguoitao + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int updateMH(string ma, string ten, string mh, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update LOAIMATHANG set TENLOAI = N'" + ten + "',NGUOISUA= N'" + nguoitao + "',MAMH = '" + mh + "' where MALOAI='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
    }
}