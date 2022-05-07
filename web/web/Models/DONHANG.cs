using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class DONHANG
    {
        string conf = "Data Source=KID;Initial Catalog=QL_NhaSach;User ID=sa";
        public string ID { get; set; }
        public string Ten { get; set; }
        public string email { get; set; }
        public string ngaylap { get; set; }
        public string dc { get; set; }
        public string tinh { get; set; }
        public string quan { get; set; }
        public string tt { get; set; }
        public string sdt { get; set; }
        public string masp { get; set; }
        public string sl { get; set; }
        public string thanhtien { get; set; }
        public string trangthai { get; set; }
        public string phuongxa { get; set; }
        public string makm { get; set; }
        public string tiengiam { get; set; }
        public string makh { get; set; }
        public int them(string hoten, string email, string sdt, string dc, string p, string tinh, string quan, string makm)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into DONHANG(HOTEN,EMAIL,SDT,DIACHI,PHUONGXA,THANHPHO,QUANHUYEN,MAKHM) values(N'" + hoten + "',N'" + email + "','" + sdt + "',N'" + dc + "',N'" + p + "',N'" + tinh + "',N'" + quan + "','" + makm + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int themKH(int makh, string hoten, string email, string sdt, string dc, string p, string tinh, string quan, string makm)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into DONHANG(makh,HOTEN,EMAIL,SDT,DIACHI,PHUONGXA,THANHPHO,QUANHUYEN,MAKHM) values('" + makh + "',N'" + hoten + "',N'" + email + "','" + sdt + "',N'" + dc + "',N'" + p + "',N'" + tinh + "',N'" + quan + "','" + makm + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int them2(string hoten, string email, string sdt, string dc, string p, string tinh, string quan)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into DONHANG(HOTEN,EMAIL,SDT,DIACHI,PHUONGXA,THANHPHO,QUANHUYEN) values(N'" + hoten + "',N'" + email + "','" + sdt + "',N'" + dc + "',N'" + p + "',N'" + tinh + "',N'" + quan + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int themKH2(int makh, string hoten, string email, string sdt, string dc, string p, string tinh, string quan)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into DONHANG(makh,HOTEN,EMAIL,SDT,DIACHI,PHUONGXA,THANHPHO,QUANHUYEN) values('" + makh + "',N'" + hoten + "',N'" + email + "','" + sdt + "',N'" + dc + "',N'" + p + "',N'" + tinh + "',N'" + quan + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int CT(string masp, int SL, int tt)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd2 = new SqlCommand("select top 1 MADH from DONHANG order by MADH DESC", con);
            cmd2.CommandType = CommandType.Text;

            Object kq = cmd2.ExecuteScalar();
            SqlCommand cmd = new SqlCommand("insert into DONHANGCT(MADH,MASP,SL,THANHTIEN) values(N'" + kq + "',N'" + masp + "',N'" + SL + "',N'" + tt + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int update(string masp)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd2 = new SqlCommand("select top 1 MADH from DONHANG order by MADH DESC", con);
            cmd2.CommandType = CommandType.Text;

            Object kq = cmd2.ExecuteScalar();

            SqlCommand cmd = new SqlCommand("update DONHANG set tongtien+=(select THANHTIEN from DONHANGCT where masp='" + masp + "' and MADH='" + kq + "') where MADH='" + kq + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int update2(float tt)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd2 = new SqlCommand("select top 1 MADH from DONHANG order by MADH DESC", con);
            cmd2.CommandType = CommandType.Text;

            Object kq = cmd2.ExecuteScalar();

            SqlCommand cmd = new SqlCommand("update DONHANG set tiengiam='" + tt + "' where MADH='" + kq + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public Object hd()
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd2 = new SqlCommand("select top 1 MADH from DONHANG order by MADH DESC", con);
            cmd2.CommandType = CommandType.Text;

            Object kq = cmd2.ExecuteScalar();
            con.Close();
            return kq;
        }
        public List<DONHANG> getData(string sr)
        {
            List<DONHANG> listBH = new List<DONHANG>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from DONHANG where madh='" + sr + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DONHANG emp = new DONHANG();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(14).ToString();
                emp.email = dr.GetValue(9).ToString();
                emp.sdt = dr.GetValue(4).ToString();
                emp.dc = dr.GetValue(15).ToString();
                emp.tinh = dr.GetValue(6).ToString();
                emp.quan = dr.GetValue(7).ToString();
                emp.ngaylap = dr.GetValue(1).ToString();
                emp.tt = dr.GetValue(2).ToString();
                emp.phuongxa = dr.GetValue(8).ToString();
                emp.tiengiam = dr.GetValue(16).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<DONHANG> getData(string sr, int makh)
        {
            List<DONHANG> listBH = new List<DONHANG>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from DONHANG where madh='" + sr + "' and makh='" + makh + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DONHANG emp = new DONHANG();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(14).ToString();
                emp.email = dr.GetValue(9).ToString();
                emp.sdt = dr.GetValue(4).ToString();
                emp.dc = dr.GetValue(15).ToString();
                emp.tinh = dr.GetValue(6).ToString();
                emp.quan = dr.GetValue(7).ToString();
                emp.ngaylap = dr.GetValue(1).ToString();
                emp.tt = dr.GetValue(2).ToString();
                emp.phuongxa = dr.GetValue(8).ToString();
                emp.tiengiam = dr.GetValue(16).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<DONHANG> getData(int makh)
        {
            List<DONHANG> listBH = new List<DONHANG>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from DONHANG where makh='" + makh + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DONHANG emp = new DONHANG();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(14).ToString();
                emp.email = dr.GetValue(9).ToString();
                emp.sdt = dr.GetValue(4).ToString();
                emp.dc = dr.GetValue(15).ToString();
                emp.tinh = dr.GetValue(6).ToString();
                emp.quan = dr.GetValue(7).ToString();
                emp.ngaylap = dr.GetValue(1).ToString();
                emp.tt = dr.GetValue(2).ToString();
                emp.phuongxa = dr.GetValue(8).ToString();
                emp.tiengiam = dr.GetValue(16).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<DONHANG> getDataAd()
        {
            List<DONHANG> listBH = new List<DONHANG>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from DONHANG", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DONHANG emp = new DONHANG();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(14).ToString();
                emp.email = dr.GetValue(9).ToString();
                emp.sdt = dr.GetValue(4).ToString();
                emp.dc = dr.GetValue(14).ToString();
                emp.tinh = dr.GetValue(6).ToString();
                emp.quan = dr.GetValue(7).ToString();
                emp.ngaylap = dr.GetValue(1).ToString();
                emp.makm = dr.GetValue(13).ToString();
                emp.tt = dr.GetValue(2).ToString();
                emp.phuongxa = dr.GetValue(8).ToString();
                emp.tiengiam = dr.GetValue(16).ToString();
                emp.trangthai = dr.GetValue(11).ToString();
                emp.makh = dr.GetValue(12).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<DONHANG> getData2(string ma)
        {
            List<DONHANG> listBH = new List<DONHANG>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select DONHANGCT.madh,masp,sl,thanhtien,TRANGTHAI from DONHANGCT,DONHANG where DONHANGCT.madh='" + ma + "' and DONHANGCT.madh=DONHANG.madh", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DONHANG emp = new DONHANG();
                emp.ID = dr.GetValue(0).ToString();
                emp.masp = dr.GetValue(1).ToString();
                emp.sl = dr.GetValue(2).ToString();
                emp.thanhtien = dr.GetValue(3).ToString();
                emp.trangthai = dr.GetValue(4).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public void update3(string ma)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update DONHANG set TRANGTHAI= 4 where madh='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update4(string ma)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update DONHANG set TRANGTHAI= 2 where madh='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
        }
        public bool update5(string ma, string cn,List<DONHANG> dataList)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SPCHINHANH CN = new SPCHINHANH();
            foreach (var item in dataList)
            {
                var data = CN.getData(item.masp,cn,item.sl);
                if (data <= 0)
                {
                    return false;
                }
            }
            SqlCommand cmd = new SqlCommand("update DONHANG set TRANGTHAI= 3 where madh='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            foreach (var item in dataList)
            {
                con.Open();
                CN.updateSLDH(item.masp, int.Parse(item.sl), cn);
                con.Close();
            }

            return true;
        }
        public void update6(string ma)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update DONHANG set TRANGTHAI= 4 where madh='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update7(string ma)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update DONHANG set TRANGTHAI= 5 where madh='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            var menu = getData2(ma);
            foreach (var item in menu)
            {
                SqlCommand cmd1 = new SqlCommand("update Sanpham set SLTON=SLTON-(" + item.sl + ") where masp='" + item.masp + "'", con);
                cmd1.CommandType = CommandType.Text;
                dr = cmd1.ExecuteNonQuery();
            }
            con.Close();
        }
        public void update8(string ma, string cn, List<DONHANG> dataList)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SPCHINHANH CN = new SPCHINHANH();
            foreach (var item in dataList)
            {
                con.Open();
                CN.updateSLDH2(item.masp, int.Parse(item.sl), cn);
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("update DONHANG set TRANGTHAI= 6 where madh='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<DONHANG> getData()
        {
            List<DONHANG> listBH = new List<DONHANG>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from HoaDon", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DONHANG emp = new DONHANG();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(13).ToString();
                emp.email = dr.GetValue(9).ToString();
                emp.sdt = dr.GetValue(4).ToString();
                emp.dc = dr.GetValue(14).ToString();
                emp.tinh = dr.GetValue(6).ToString();
                emp.quan = dr.GetValue(7).ToString();
                emp.ngaylap = dr.GetValue(2).ToString();
                emp.tt = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
    }
}