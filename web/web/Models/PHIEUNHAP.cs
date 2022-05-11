using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class PHIEUNHAP
    {
        public string conf = "Data Source=LAPTOP-G07FAD75;Initial Catalog=QL_NhaSach;User ID=sa";
        public string MAPHIEU { get; set; }
        public string SOHD { get; set; }
        public string KYHIEU { get; set; }
        public string KYHIEUMAU { get; set; }
        public string NGAYNHAP { get; set; }
        public string NGAYHD { get; set; }
        public string NGAYNHANHD { get; set; }
        public string MACN { get; set; }
        public string TONG { get; set; }
        public string VAT { get; set; }
        public string TIENVAT { get; set; }
        public string THANHTIENVAT { get; set; }
        public string GHICHU { get; set; }
        public string NGUOITAO { get; set; }
        public string NGAYTAO { get; set; }
        public string TRANGTHAI { get; set; }
        public string MASP { get; set; }
        public string SL { get; set; }
        public string MANCC { get; set; }
        public List<PHIEUNHAP> getData()
        {
            List<PHIEUNHAP> listBH = new List<PHIEUNHAP>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from PHIEUNHAP", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PHIEUNHAP emp = new PHIEUNHAP();
                emp.MAPHIEU = dr.GetValue(0).ToString();
                emp.SOHD = dr.GetValue(1).ToString();
                emp.KYHIEU = dr.GetValue(2).ToString();
                emp.KYHIEUMAU = dr.GetValue(3).ToString();
                emp.NGAYNHAP = dr.GetValue(4).ToString();
                emp.NGAYHD = dr.GetValue(5).ToString();
                emp.NGAYNHANHD = dr.GetValue(6).ToString();
                emp.MACN = dr.GetValue(7).ToString();
                emp.TONG = dr.GetValue(8).ToString();
                emp.VAT = dr.GetValue(9).ToString();
                emp.TIENVAT = dr.GetValue(10).ToString();
                emp.THANHTIENVAT = dr.GetValue(11).ToString();
                emp.GHICHU = dr.GetValue(12).ToString();
                emp.NGUOITAO = dr.GetValue(13).ToString();
                emp.NGAYTAO = dr.GetValue(14).ToString();
                emp.TRANGTHAI = dr.GetValue(16).ToString();
                emp.MANCC = dr.GetValue(18).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<PHIEUNHAP> getDataCT(string ma)
        {
            List<PHIEUNHAP> listBH = new List<PHIEUNHAP>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from PHIEUNHAP where maphieu='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PHIEUNHAP emp = new PHIEUNHAP();
                emp.MAPHIEU = dr.GetValue(0).ToString();
                emp.SOHD = dr.GetValue(1).ToString();
                emp.KYHIEU = dr.GetValue(2).ToString();
                emp.KYHIEUMAU = dr.GetValue(3).ToString();
                emp.NGAYNHAP = dr.GetValue(4).ToString();
                emp.NGAYHD = dr.GetValue(5).ToString();
                emp.NGAYNHANHD = dr.GetValue(6).ToString();
                emp.MACN = dr.GetValue(7).ToString();
                emp.TONG = dr.GetValue(8).ToString();
                emp.VAT = dr.GetValue(9).ToString();
                emp.TIENVAT = dr.GetValue(10).ToString();
                emp.THANHTIENVAT = dr.GetValue(11).ToString();
                emp.GHICHU = dr.GetValue(12).ToString();
                emp.NGUOITAO = dr.GetValue(13).ToString();
                emp.NGAYTAO = dr.GetValue(14).ToString();
                emp.TRANGTHAI = dr.GetValue(16).ToString();
                emp.MANCC = dr.GetValue(18).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int them(string sohd, string kyhieuhd, string kyhieumauhd, string ngaynhap, string ngayhd, string ngaynhanhd, string macn, string tong, string vat, string tienvat, string thanhtienvat, string ghichu, string nguoitao, string mancc)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into PHIEUNHAP(SOHD,KYHIEUHD,KYHIEUMAUDH,NGAYNHAP,NGAYHD,NGAYNHANHD,MACN,TONG,VAT,TIENVAT,THANHTIENVAT,GHICHU,NGUOITAO,MANCC) values(N'" + sohd + "',N'" + kyhieuhd + "',N'" + kyhieumauhd + "',N'" + ngaynhap + "',N'" + ngayhd + "',N'" + ngaynhanhd + "',N'" + macn + "','" + tong + "','" + vat + "','" + tienvat + "','" + thanhtienvat + "','" + ghichu + "','" + nguoitao + "','" + mancc + "')", con);
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
            SqlCommand cmd2 = new SqlCommand("select top 1 MAPHIEU from PHIEUNHAP order by MAPHIEU DESC", con);
            cmd2.CommandType = CommandType.Text;
            Object kq = cmd2.ExecuteScalar();
            con.Close();
            return int.Parse(kq.ToString());
        }
        public void themCT(int maphieu, string masp, string dg, string dgvat, string tt, string ttvat, string sl)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into PHIEUNHAPCT(MAPHIEU,MASP,SL,THANHTIEN,THANHTIENVAT,DONGIA,DONGIAVAT) values(N'" + maphieu + "',N'" + masp.ToString() + "',N'" + sl + "',N'" + tt + "',N'" + ttvat + "',N'" + dg + "',N'" + dgvat + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update1(string ma, string manv)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update PHIEUNHAP set TRANGTHAI= 2,nguoisua=N'" + manv + "',ngaysua= '" + new DateTime() + "' where maphieu='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updateAll(int maphieu)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd2 = new SqlCommand("update PHIEUNHAPCT set disabled= 1 where maphieu='" + maphieu + "'", con);
            cmd2.CommandType = CommandType.Text;
            dr = cmd2.ExecuteNonQuery();
            con.Close();
        }
        public void update(int maphieu, string sohd, string kyhieuhd, string kyhieumauhd, string ngaynhap, string ngayhd, string ngaynhanhd, string macn, string tong, string vat, string tienvat, string thanhtienvat, string ghichu, string nguoitao, string mancc)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update PHIEUNHAP set sohd='" + sohd + "',kyhieuhd = '" + kyhieuhd + "',KYHIEUMAUDH = '" + kyhieumauhd + "',ngaynhap = '" + ngaynhap + "',ngayhd = '" + ngayhd + "',ngaynhanhd='" + ngaynhanhd + "',macn='" + macn + "',tong='" + tong + "',vat='" + vat + "',tienvat ='" + tienvat + "',thanhtienvat = '" + thanhtienvat + "',ghichu='" + ghichu + "',nguoisua='" + nguoitao + "',ngaysua='" + new DateTime() + "',mancc='" + mancc + "'  where maphieu='" + maphieu + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update2(string ma, string manv)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update PHIEUNHAP set TRANGTHAI= 1,nguoisua=N'" + manv + "',ngaysua= '" + new DateTime() + "' where maphieu='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            List<PHIEUNHAP> listBH2 = new List<PHIEUNHAP>();
            SqlCommand cmd4 = new SqlCommand("select * from PHIEUNHAP where maphieu='" + ma + "'", con);
            cmd4.CommandType = CommandType.Text;
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                PHIEUNHAP emp = new PHIEUNHAP();
                emp.MANCC = dr4.GetValue(7).ToString();
                listBH2.Add(emp);

            }
            con.Close();
            con.Open();
            List<PHIEUNHAP> listBH = new List<PHIEUNHAP>();
            SqlCommand cmd2 = new SqlCommand("select * from PHIEUNHAPCT where maphieu='" + ma + "'", con);
            cmd2.CommandType = CommandType.Text;
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                PHIEUNHAP emp = new PHIEUNHAP();
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
                    SqlCommand cmd3 = new SqlCommand("update SANPHAMCN set SLTON= SLTON + " + item.SL + " where masp='" + item.MASP + "' and macn= '" + item2.MANCC + "'", con);
                    cmd3.CommandType = CommandType.Text;
                    cmd3.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public int KtraSpPhieu(int maphieu, string masp)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("select count(*) from PHIEUNHAPCT where masp='" + masp + "' and maphieu='" + maphieu + "'", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            Object kq = cmd2.ExecuteScalar();
            con.Close();
            return int.Parse(kq.ToString());
        }
        public void updateCTPhieus(int maphieu, string masp, string dg, string dgvat, string tt, string ttvat, string sl)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("update PHIEUNHAPCT set SL = '" + sl + "',THANHTIEN ='" + tt + "',THANHTIENVAT = '" + ttvat + "',DONGIA = '" + dg + "',DONGIAVAT = '" + dgvat + "', disabled= 0   where maphieu='" + maphieu + "' and masp ='" + masp + "'", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
    }
}