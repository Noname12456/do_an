using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class CHINHANH
    {
        public string conf = "Data Source=KID;Initial Catalog=QL_NhaSach;User ID=sa";
        public string ID { get; set; }
        public string Ten { get; set; }
        public string DC { get; set; }
        public string SDT { get; set; }
        public string mota { get; set; }
        public string STK { get; set; }
        public int ktra2(string matg)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("select count(*) from CHINHANH where MACN = '" + matg + "'", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            Object kq = cmd2.ExecuteScalar();
            con.Close();
            return int.Parse(kq.ToString());

        }
        public int them(string ma, string ten, string dc, string sdt, string mota, string stk, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into CHINHANH(MACN,TENCN,DC,SDT,MOTA,STK,NGUOITAO) values(N'" + ma + "',N'" + ten + "',N'" + dc + "',N'" + sdt + "',N'" + mota + "',N'" + stk + "',N'" + nguoitao + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public List<NXB> getData3(string id)
        {
            List<NXB> listBH = new List<NXB>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from CHINHANH where MACN='" + id + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NXB emp = new NXB();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                emp.DC = dr.GetValue(2).ToString();
                emp.mota = dr.GetValue(4).ToString();
                emp.STK = dr.GetValue(5).ToString();
                emp.SDT = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int update(string ma, string ten, string dc, string sdt, string mota, string gt, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update CHINHANH set TENCN = N'" + ten + "',DC= N'" + dc + "',SDT = '" + sdt + "',MOTA = '" + mota + "',stk = '" + gt + "',NGUOISUA = '" + nguoitao + "' where MACN='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public List<NXB> getData2()
        {
            List<NXB> listBH = new List<NXB>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from CHINHANH", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NXB emp = new NXB();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                emp.DC = dr.GetValue(2).ToString();
                emp.SDT = dr.GetValue(3).ToString();
                emp.STK = dr.GetValue(4).ToString();
                emp.mota = dr.GetValue(5).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
    }
}