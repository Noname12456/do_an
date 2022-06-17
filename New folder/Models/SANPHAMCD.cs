using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace web.Models
{
    public class SANPHAMCD
    {
        public string conf = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public string ID { get; set; }
        public string Ten { get; set; }
        public List<SANPHAMCD> getData(string masp)
        {
            List<SANPHAMCD> listBH = new List<SANPHAMCD>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from LOAICHUDE,SANPHAMLOAICHUDE where LOAICHUDE.MALOAICD=SANPHAMLOAICHUDE.MALOAICD and masp='" + masp + "' and SANPHAMLOAICHUDE.disabled = 0", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAMCD emp = new SANPHAMCD();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int ktra(string ma,string mal)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("select count(*) from SANPHAMLOAICHUDE where MALOAICD='" + mal + "' and masp = '" + ma + "'", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            Object kq = cmd2.ExecuteScalar();
            con.Close();
            return int.Parse(kq.ToString());

        }
    }
}