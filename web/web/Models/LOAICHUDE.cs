using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class LOAICHUDE
    {
        public string conf = "Data Source=KID;Initial Catalog=QL_NhaSach;User ID=sa";
        public string ID { get; set; }
        public string Ten { get; set; }
        public string MACD { get; set; }
        public List<LOAICHUDE> getData(string macd)
        {
            List<LOAICHUDE> listBH = new List<LOAICHUDE>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from LOAICHUDE where disabled=0 and macd='" + macd + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAICHUDE emp = new LOAICHUDE();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<LOAICHUDE> getData()
        {
            List<LOAICHUDE> listBH = new List<LOAICHUDE>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select LOAICHUDE.* from LOAICHUDE Inner join CHUDE on (LOAICHUDE.MACD=CHUDE.MACD) Inner join LOAIMATHANG on (LOAIMATHANG.MALOAI=CHUDE.MALOAI)  Inner join MATHANG on (LOAIMATHANG.MAMH=MATHANG.MAMH) where LOAICHUDE.disabled=0 and MATHANG.MAMH= 'MH001'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAICHUDE emp = new LOAICHUDE();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<LOAICHUDE> getData2()
        {
            List<LOAICHUDE> listBH = new List<LOAICHUDE>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select LOAICHUDE.* from LOAICHUDE Inner join CHUDE on (LOAICHUDE.MACD=CHUDE.MACD) Inner join LOAIMATHANG on (LOAIMATHANG.MALOAI=CHUDE.MALOAI)  Inner join MATHANG on (LOAIMATHANG.MAMH=MATHANG.MAMH) where LOAICHUDE.disabled=0 and MATHANG.MAMH= 'MH002' or MATHANG.MAMH= 'MH003'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAICHUDE emp = new LOAICHUDE();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<LOAICHUDE> getData3()
        {
            List<LOAICHUDE> listBH = new List<LOAICHUDE>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select LOAICHUDE.* from LOAICHUDE Inner join CHUDE on (LOAICHUDE.MACD=CHUDE.MACD) Inner join LOAIMATHANG on (LOAIMATHANG.MALOAI=CHUDE.MALOAI)  Inner join MATHANG on (LOAIMATHANG.MAMH=MATHANG.MAMH) where LOAICHUDE.disabled=0 and MATHANG.MAMH!= 'MH001'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAICHUDE emp = new LOAICHUDE();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<LOAICHUDE> getData4()
        {
            List<LOAICHUDE> listBH = new List<LOAICHUDE>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select LOAICHUDE.* from LOAICHUDE ", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAICHUDE emp = new LOAICHUDE();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<LOAICHUDE> getData5(string ma)
        {
            List<LOAICHUDE> listBH = new List<LOAICHUDE>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select CHUDE.* from LOAICHUDE,CHUDE where chude.macd= loaichude.macd and maloaicd='" + ma + "' ", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAICHUDE emp = new LOAICHUDE();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int getData6(string ma)
        {
            List<LOAIMATHANG> listBH = new List<LOAIMATHANG>();
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Count(*) from LOAICHUDE where MALOAICD='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            Object kq = cmd.ExecuteScalar();
            con.Close();
            return int.Parse(kq.ToString());
        }
        public int themLCD(string ma, string ten, string mh, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into LOAICHUDE(MALOAICD,TENLOAICD,MACD,NGUOITAO) values(N'" + ma + "',N'" + ten + "','" + mh + "',N'" + nguoitao + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int updateLCD(string ma, string ten, string mh, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update LOAICHUDE set TENLOAICD = N'" + ten + "',NGUOISUA= N'" + nguoitao + "',MACD = '" + mh + "' where MALOAICD='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public List<LOAICHUDE> getData7(string ma)
        {
            List<LOAICHUDE> listBH = new List<LOAICHUDE>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from LOAICHUDE where MALOAICD='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAICHUDE emp = new LOAICHUDE();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                emp.MACD = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
    }
}