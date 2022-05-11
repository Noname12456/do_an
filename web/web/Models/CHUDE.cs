using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using web.Models;
namespace web.Models
{
    public class CHUDE
    {
        public string conf = "Data Source=LAPTOP-G07FAD75;Initial Catalog=QL_NhaSach;User ID=sa";
        public string ID { get; set; }
        public string MALOAI { get; set; }
        public string Ten { get; set; }
        public List<CHUDE> getData(string maloai)
        {
            List<CHUDE> listBH = new List<CHUDE>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from CHUDE where disabled=0 and MALOAI='" + maloai + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CHUDE emp = new CHUDE();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<CHUDE> getData2(string maloai)
        {
            List<CHUDE> listBH = new List<CHUDE>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select LOAIMATHANG.* from CHUDE,LOAIMATHANG where CHUDE.MALOAI = LOAIMATHANG.MALOAI and CHUDE.MACD='" + maloai + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CHUDE emp = new CHUDE();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<CHUDE> getData()
        {
            List<CHUDE> listBH = new List<CHUDE>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from CHUDE", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CHUDE emp = new CHUDE();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int themCD(string ma, string ten, string mh, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into CHUDE(MACD,TENCD,MALOAI,NGUOITAO) values(N'" + ma + "',N'" + ten + "','" + mh + "',N'" + nguoitao + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int updateCD(string ma, string ten, string mh, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update CHUDE set TENCD = N'" + ten + "',NGUOISUA= N'" + nguoitao + "',MALOAI = '" + mh + "' where MACD='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int getData3(string ma)
        {
            List<LOAIMATHANG> listBH = new List<LOAIMATHANG>();
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Count(*) from CHUDE where MACD='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            Object kq = cmd.ExecuteScalar();
            con.Close();
            return int.Parse(kq.ToString());
        }
        public List<CHUDE> getData4(string ma)
        {
            List<CHUDE> listBH = new List<CHUDE>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from CHUDE where MACD='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CHUDE emp = new CHUDE();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                emp.MALOAI = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
    }
}