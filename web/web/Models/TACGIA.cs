using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class TACGIA
    {
        public string conf = "Data Source=KID;Initial Catalog=QL_NhaSach;User ID=sa";
        public string ID { get; set; }
        public string Ten { get; set; }
        public string DC { get; set; }
        public string SDT { get; set; }
        public string mota { get; set; }
        public string GT { get; set; }
        public List<TACGIA> getData(string masp)
        {
            List<TACGIA> listBH = new List<TACGIA>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from TACGIA,SachTG where TACGIA.matg=SachTG.matg and masp='" + masp + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TACGIA emp = new TACGIA();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<TACGIA> getData2(string masp)
        {
            List<TACGIA> listBH = new List<TACGIA>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from TACGIA,SachTG where TACGIA.matg=SachTG.matg and masp='" + masp + "' and SachTG.disabled = 0", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TACGIA emp = new TACGIA();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<TACGIA> getData()
        {
            List<TACGIA> listBH = new List<TACGIA>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from TACGIA", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TACGIA emp = new TACGIA();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                emp.DC = dr.GetValue(2).ToString();
                emp.mota = dr.GetValue(4).ToString();
                emp.GT = dr.GetValue(5).ToString();
                emp.SDT = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int ktra(string ma,string matg)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("select count(*) from SACHTG where masp='" + ma + "' and matg = '" + matg + "'", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            Object kq = cmd2.ExecuteScalar();
            con.Close();
            return int.Parse(kq.ToString());

        }
        public int ktra2(string matg)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("select count(*) from TACGIA where matg = '" + matg + "'", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            Object kq = cmd2.ExecuteScalar();
            con.Close();
            return int.Parse(kq.ToString());

        }
        public int them(string ma, string ten, string dc, string sdt, string mota, string gt, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into TACGIA(MATG,TENTG,DC,SDT,MOTA,GT,NGUOITAO) values(N'" + ma + "',N'" + ten + "',N'" + dc + "',N'" + sdt + "',N'" + mota + "',N'" + gt + "',N'" + nguoitao + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public List<TACGIA> getData3(string id)
        {
            List<TACGIA> listBH = new List<TACGIA>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from TACGIA where matg='" + id + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TACGIA emp = new TACGIA();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                emp.DC = dr.GetValue(2).ToString();
                emp.mota = dr.GetValue(4).ToString();
                emp.GT = dr.GetValue(5).ToString();
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
            SqlCommand cmd = new SqlCommand("update TACGIA set TENTG = N'" + ten + "',DC= N'" + dc + "',SDT = '" + sdt + "',MOTA = '" + mota + "',GT = '" + gt + "',NGUOISUA = '" + nguoitao + "' where matg='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
    }
}