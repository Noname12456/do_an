using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class QUYEN
    {
        public string conf = "Data Source=LAPTOP-G07FAD75;Initial Catalog=QL_NhaSach;User ID=sa";
        public string ID { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public int them(string ma, string ten)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into QUYEN(MAQUYEN,TENQUYEN) values(N'" + ma + "',N'" + ten + "')", con);
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
            SqlCommand cmd = new SqlCommand("update QUYEN set TENQUYEN =N'"+ten+"' where maquyen = '"+ma+"'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public List<QUYEN> getData()
        {
            List<QUYEN> listBH = new List<QUYEN>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from QUYEN", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                QUYEN emp = new QUYEN();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ma = dr.GetValue(1).ToString();
                emp.Ten = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<QUYEN> getData(string ma)
        {
            List<QUYEN> listBH = new List<QUYEN>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from QUYEN where idquyen ='"+ma+"'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                QUYEN emp = new QUYEN();
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