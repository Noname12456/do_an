using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace web.Models
{
    public class PHIEUXUAT
    {
        public string conf = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public string MAPHIEU { get; set; }
        public string NGAYXUAT { get; set; }
        public string MACNXUAT { get; set; }
        public string MACNNHAP { get; set; }
        public string NOINHAN { get; set; }
        public string GHICHU { get; set; }
        public string NGUOITAO { get; set; }
        public string NGAYTAO { get; set; }
        public string TRANGTHAI { get; set; }
        public string MASP { get; set; }
        public string SL { get; set; }
        public string NAME { get; set; }
        public List<PHIEUXUAT> getData()
        {
            List<PHIEUXUAT> listBH = new List<PHIEUXUAT>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from PHIEUXUAT", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PHIEUXUAT emp = new PHIEUXUAT();
                emp.MAPHIEU = dr.GetValue(0).ToString();
                emp.MACNXUAT = dr.GetValue(2).ToString();
                emp.GHICHU = dr.GetValue(5).ToString();
                emp.NOINHAN = dr.GetValue(4).ToString();
                emp.NGUOITAO = dr.GetValue(6).ToString();
                emp.NGAYXUAT = dr.GetValue(1).ToString();
                emp.NGAYTAO = dr.GetValue(7).ToString();
                emp.TRANGTHAI = dr.GetValue(9).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<PHIEUXUAT> getDataCT(String id)
        {
            List<PHIEUXUAT> listBH = new List<PHIEUXUAT>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from PHIEUXUAT where maphieu='" + id + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PHIEUXUAT emp = new PHIEUXUAT();
                emp.MAPHIEU = dr.GetValue(0).ToString();
                emp.MACNXUAT = dr.GetValue(2).ToString();
                emp.GHICHU = dr.GetValue(5).ToString();
                emp.NOINHAN = dr.GetValue(4).ToString();
                emp.NGUOITAO = dr.GetValue(6).ToString();
                emp.NGAYXUAT = dr.GetValue(1).ToString();
                emp.NGAYTAO = dr.GetValue(7).ToString();
                emp.TRANGTHAI = dr.GetValue(9).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<PHIEUXUAT> getDataCTPHIEU(String id)
        {
            List<PHIEUXUAT> listBH = new List<PHIEUXUAT>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from PHIEUXUATCT,sanpham where maphieu='" + id + "' and sanpham.masp=PHIEUXUATCT.masp", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PHIEUXUAT emp = new PHIEUXUAT();
                emp.MASP = dr.GetValue(1).ToString();
                emp.SL = dr.GetValue(2).ToString();
                emp.GHICHU = dr.GetValue(3).ToString();
                emp.NAME = dr.GetValue(6).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int them(string manc, string noinhan, string ghichu, string ngayxuat, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into PHIEUXUAT(MACNGUI,NOINHAN,GHICHU,NGUOITAO,NGAYXUAT) values(N'" + manc + "',N'" + noinhan + "',N'" + ghichu + "',N'" + nguoitao + "',N'" + ngayxuat + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int LayId()
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd2 = new SqlCommand("select top 1 MAPHIEU from PHIEUXUAT order by MAPHIEU DESC", con);
            cmd2.CommandType = CommandType.Text;
            Object kq = cmd2.ExecuteScalar();
            con.Close();
            return int.Parse(kq.ToString());
        }
        public void themCT(int maphieu, string masp, string sl, string ghichu)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into PHIEUXUATCT(MAPHIEU,MASP,SL,GHICHU) values(N'" + maphieu + "',N'" + masp.ToString() + "',N'" + sl + "',N'" + ghichu + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update1(string ma, string manv)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update PHIEUXUAT set TRANGTHAI= 7,nguoisua=N'" + manv + "',ngaysua= '" + new DateTime() + "' where maphieu='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update2(string ma, string manv)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update PHIEUXUAT set TRANGTHAI= 6,nguoisua=N'" + manv + "',ngaysua= '" + new DateTime() + "' where maphieu='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            List<PHIEUXUAT> listBH2 = new List<PHIEUXUAT>();
            SqlCommand cmd4 = new SqlCommand("select * from PHIEUXUAT where maphieu='" + ma + "'", con);
            cmd4.CommandType = CommandType.Text;
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                PHIEUXUAT emp = new PHIEUXUAT();
                emp.MACNXUAT = dr4.GetValue(2).ToString();
                listBH2.Add(emp);

            }
            con.Close();
            con.Open();
            List<PHIEUXUAT> listBH = new List<PHIEUXUAT>();
            SqlCommand cmd2 = new SqlCommand("select * from PHIEUXUATCT where maphieu='" + ma + "'", con);
            cmd2.CommandType = CommandType.Text;
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                PHIEUXUAT emp = new PHIEUXUAT();
                emp.MASP = dr2.GetValue(1).ToString();
                emp.SL = dr2.GetValue(2).ToString();
                listBH.Add(emp);

            }
            con.Close();
            foreach (var item in listBH)
            {
                foreach (var item2 in listBH2)
                {
                    con.Open();
                    SqlCommand cmd3 = new SqlCommand("update SANPHAMCN set SLTON= SLTON - " + item.SL + " where masp='" + item.MASP + "' and macn= '" + item2.MACNXUAT + "'", con);
                    cmd3.CommandType = CommandType.Text;
                    cmd3.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public void update(int maphieu, string manc, string noinhan, string ghichu, string ngayxuat, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update PHIEUXUAT set MACNGUI = '"+manc+"',NOINHAN = '"+noinhan+"',GHICHU = '"+ghichu+"',NGUOISUA = '"+nguoitao+"',NGAYXUAT = '"+ngayxuat+"' where maphieu = '"+maphieu+"'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updateAll(int maphieu)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update PHIEUXUATCT set disabled = 1 where maphieu ='" + maphieu + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
        }
        public int KtraSpPhieu(int maphieu, string masp)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("select count(*) from PHIEUXUATCT where masp='" + masp + "' and maphieu='" + maphieu + "'", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            Object kq = cmd2.ExecuteScalar();
            con.Close();
            return int.Parse(kq.ToString());
        }
        public void updateCTPhieus(int maphieu, string masp, string sl, string ghichu)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("update PHIEUXUATCT set SL = '" + sl + "',GHICHU = '" + ghichu + "', disabled= 0   where maphieu='" + maphieu + "' and masp ='" + masp + "'", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
    }
}