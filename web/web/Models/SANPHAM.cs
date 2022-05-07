using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PagedList;
namespace web.Models
{
    public class SANPHAM
    {
        string conf = "Data Source=KID;Initial Catalog=QL_NhaSach;User ID=sa";
        public string MASP { get; set; }
        public string TENSP { get; set; }
        public string NGAYDANG { get; set; }
        public string GIABAN { get; set; }
        public string GIANHAP { get; set; }
        public string MANCC { get; set; }
        public string MANXB { get; set; }
        public string XUATXU { get; set; }
        public string THUONGHIEU { get; set; }
        public string NGONNGU { get; set; }
        public string KICHTHUOC { get; set; }
        public string SOTRANG { get; set; }
        public string MOTA { get; set; }
        public string DOTUOI { get; set; }
        public string HSD { get; set; }
        public string SLTON { get; set; }
        public string TRONGLUONG { get; set; }
        public string MALOAIMH { get; set; }
        public string MACD { get; set; }
        public string MALCD { get; set; }
        public int disabled { get; set; }
        public List<SANPHAM> getData(string sr)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select DISTINCT  SANPHAM.MASP,SANPHAM.TENSP,GIABAN from SANPHAM Inner join SACHTG on (SACHTG.MASP=SANPHAM.MASP)  Inner join TACGIA on (SACHTG.MATG=SACHTG.MATG)  where (TENSP like N'%" + sr + "%' or SANPHAM.MASP like N'%" + sr + "%' or TENTG like N'%" + sr + "%')  and SANPHAM.disabled=0 union  ALL  select DISTINCT  SANPHAM.MASP,SANPHAM.TENSP,GIABAN from SANPHAM LEFT join SACHTG on (SACHTG.MASP=SANPHAM.MASP) where (TENSP like N'%" + sr + "%' or SANPHAM.MASP like N'%" + sr + "%') and SANPHAM.disabled=0", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<SANPHAM> getDataSP(string malcd, int limit)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select top " + limit + " * from Sanpham,SANPHAMLOAICHUDE where Sanpham.disabled=0 and SANPHAMLOAICHUDE.masp=sanpham.masp and SANPHAMLOAICHUDE.MALOAICD= '" + malcd + "' order by ngaydang", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<SANPHAM> getDataSP2(string malcd, int limit, int limit2)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select* from Sanpham,SANPHAMLOAICHUDE where Sanpham.disabled=0 and SANPHAMLOAICHUDE.masp=sanpham.masp and SANPHAMLOAICHUDE.MALOAICD= '" + malcd + "'  order by ngaydang  OFFSET " + limit + " ROWS FETCH NEXT " + limit2 + " ROWS ONLY", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<SANPHAM> getDataCT(string masp)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from Sanpham where masp='" + masp + "' and disabled=0", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(3).ToString();
                emp.GIANHAP = dr.GetValue(4).ToString();
                emp.MANCC = dr.GetValue(5).ToString();
                emp.MANXB = dr.GetValue(6).ToString();
                emp.XUATXU = dr.GetValue(7).ToString();
                emp.THUONGHIEU = dr.GetValue(8).ToString();
                emp.NGONNGU = dr.GetValue(9).ToString();
                emp.KICHTHUOC = dr.GetValue(10).ToString();
                emp.SOTRANG = dr.GetValue(11).ToString();
                emp.MOTA = dr.GetValue(12).ToString();
                emp.DOTUOI = dr.GetValue(13).ToString();
                emp.SLTON = dr.GetValue(15).ToString();
                emp.TRONGLUONG = dr.GetValue(16).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<SANPHAM> getDataMuaN1()
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select Top 4 SANPHAM.MASP,TenSp,GIABAN  from SanPham,DONHANGCT where SANPHAM.MASP=DONHANGCT.MASP and disabled=0  group by SANPHAM.MASP,TenSp,GIABAN having SUM(DONHANGCT.SL)>=10 order by SANPHAM.MASP,TenSp,GIABAN ", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<SANPHAM> getDataMuaN2()
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select SANPHAM.MASP,TenSp,GIABAN  from SanPham,DONHANGCT where SANPHAM.MASP=DONHANGCT.MASP and disabled=0  group by SANPHAM.MASP,TenSp,GIABAN  having Sum(DONHANGCT.SL)>=10 order by SANPHAM.MASP,TenSp,GIABAN OFFSET 5 ROWS FETCH NEXT 4 ROWS ONLY", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<SANPHAM> getDataMuaLQ1(string listLoaiCD)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select Top 6 *  from SanPham,sanphamloaichude where sanpham.masp = sanphamloaichude.masp and maloaicd IN (" + listLoaiCD + ") and SanPham.disabled=0 ORDER BY RAND() ", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public IEnumerable<SANPHAM> getDataLMH(int page, int pagesize, string maloai)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select DISTINCT SANPHAM.MASP,SANPHAM.TENSP,GIABAN,LOAIMATHANG.MALOAI from SANPHAM Inner join SANPHAMLOAICHUDE on (SANPHAM.MASP=SANPHAMLOAICHUDE.MASP) Inner join LOAICHUDE on (LOAICHUDE.MALOAICD=SANPHAMLOAICHUDE.MALOAICD) Inner join CHUDE on (CHUDE.MACD=LOAICHUDE.MACD) Inner join LOAIMATHANG on (LOAIMATHANG.MALOAI=CHUDE.MALOAI)  where LOAIMATHANG.MALOAI='" + maloai + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(2).ToString();
                emp.MALOAIMH = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH.OrderBy(x => x.MASP).ToPagedList(page, pagesize);
        }
        public IEnumerable<SANPHAM> getDataCD(int page, int pagesize, string MACD)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select DISTINCT SANPHAM.MASP,SANPHAM.TENSP,GIABAN,CHUDE.MACD from SANPHAM Inner join SANPHAMLOAICHUDE on (SANPHAM.MASP=SANPHAMLOAICHUDE.MASP) Inner join LOAICHUDE on (LOAICHUDE.MALOAICD=SANPHAMLOAICHUDE.MALOAICD) Inner join CHUDE on (CHUDE.MACD=LOAICHUDE.MACD) where CHUDE.MACD='" + MACD + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(2).ToString();
                emp.MACD = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH.OrderBy(x => x.MASP).ToPagedList(page, pagesize);
        }
        public IEnumerable<SANPHAM> getDataLCD(int page, int pagesize, string MALCD)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select DISTINCT SANPHAM.MASP,SANPHAM.TENSP,GIABAN,LOAICHUDE.MALOAICD from SANPHAM Inner join SANPHAMLOAICHUDE on (SANPHAM.MASP=SANPHAMLOAICHUDE.MASP) Inner join LOAICHUDE on (LOAICHUDE.MALOAICD=SANPHAMLOAICHUDE.MALOAICD) where LOAICHUDE.MALOAICD='" + MALCD + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(2).ToString();
                emp.MALCD = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH.OrderBy(x => x.MASP).ToPagedList(page, pagesize);
        }
        public int KtraSp(string ma)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("select count(*) from Sanpham where masp='" + ma + "'", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            Object kq = cmd2.ExecuteScalar();
            con.Close();
            return int.Parse(kq.ToString());
        }
        public int themSach(string ma, string ten, string mota, string giaban, string gianhap, string kichthuoc, string sotrang, string dotuoi, string trongluong, string mancc, string manxb, string nn, string xx,string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Sanpham(MASP,TENSP,MOTA,GIABAN,GIANHAP,KICHTHUOC,SOTRANG,DOTUOI,TRONGLUONG,MANCC,MANXB,NGONNGU,XUATXU,NGUOITAO) values(N'" + ma + "',N'" + ten + "','" + mota + "','" + giaban + "',N'" + gianhap + "','" + kichthuoc + "','" + sotrang + "',N'" + dotuoi + "','" + trongluong + "','" + mancc + "','" + manxb + "',N'" + nn + "',N'" + xx + "',N'" + nguoitao + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int SachTG(string ma, string matg,string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into SACHTG(MASP,MATG,NGUOITAO) values(N'" + ma + "',N'" + matg + "',N'" + nguoitao + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int SanPhamLCD(string ma, string malcd, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into SANPHAMLOAICHUDE(MASP,MALOAICD,NGUOITAO) values(N'" + ma + "',N'" + malcd + "',N'" + nguoitao + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int SanPhamHINH(string ma, string Hinh, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into SANPHAMHINHANH(MASP,Hinh,NGUOITAO) values(N'" + ma + "',N'" + Hinh + "',N'" + nguoitao + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public IEnumerable<SANPHAM> getDataMH()
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select DISTINCT SANPHAM.MASP,SANPHAM.TENSP,GIABAN,SANPHAM.GIANHAP,SANPHAM.disabled from SANPHAM Inner join SANPHAMLOAICHUDE on (SANPHAM.MASP=SANPHAMLOAICHUDE.MASP) Inner join LOAICHUDE on (LOAICHUDE.MALOAICD=SANPHAMLOAICHUDE.MALOAICD) Inner join CHUDE on (CHUDE.MACD=LOAICHUDE.MACD)Inner join LOAIMATHANG on (LOAIMATHANG.MALOAI=CHUDE.MALOAI) where LOAIMATHANG.MAMH = 'MH001'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(2).ToString();
                emp.GIANHAP = dr.GetValue(3).ToString();
                emp.disabled = int.Parse(dr.GetValue(4).ToString());
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int update3(string ma)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Sanpham set disabled = 1 where masp='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int update4(string ma)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Sanpham set disabled = 0 where masp='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int updateSach(string ma, string ten, string mota, string giaban, string gianhap, string kichthuoc, string sotrang, string dotuoi, string trongluong, string mancc, string manxb, string nn, string xx, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Sanpham set TENSP = N'" + ten + "',MOTA= N'" + mota + "',GIABAN= N'" + giaban + "',GIANHAP= N'" + gianhap + "',KICHTHUOC= N'" + kichthuoc + "',SOTRANG= N'" + sotrang + "',DOTUOI= N'" + dotuoi + "',TRONGLUONG= N'" + trongluong + "',MANCC= N'" + mancc + "',MANXB= N'" + manxb + "',NGONNGU= N'" + nn + "',XUATXU= N'" + xx + "',NGUOITAO= N'" + nguoitao + "' where masp='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int updateTgKhoa(string ma)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update SACHTG set disabled = 1 where masp='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int updateTgMo(string ma,string matg)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update SACHTG set disabled = 0 where masp='" + ma + "' and matg ='"+matg+"'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int updateLcdKhoa(string ma)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update SANPHAMLOAICHUDE set disabled = 1 where masp='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int updatelcdMo(string ma,string mal)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update SANPHAMLOAICHUDE set disabled = 0 where masp='" + ma + "' and MALOAICD ='" + mal + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public IEnumerable<SANPHAM> getDataMH2()
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select DISTINCT SANPHAM.MASP,SANPHAM.TENSP,GIABAN,SANPHAM.GIANHAP,SANPHAM.disabled from SANPHAM Inner join SANPHAMLOAICHUDE on (SANPHAM.MASP=SANPHAMLOAICHUDE.MASP) Inner join LOAICHUDE on (LOAICHUDE.MALOAICD=SANPHAMLOAICHUDE.MALOAICD) Inner join CHUDE on (CHUDE.MACD=LOAICHUDE.MACD)Inner join LOAIMATHANG on (LOAIMATHANG.MALOAI=CHUDE.MALOAI) where LOAIMATHANG.MAMH != 'MH001'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(2).ToString();
                emp.GIANHAP = dr.GetValue(3).ToString();
                emp.disabled = int.Parse(dr.GetValue(4).ToString());
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int themDungCu(string ma, string ten, string mota, string giaban, string gianhap, string kichthuoc, string dotuoi, string trongluong, string mancc, string xx, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Sanpham(MASP,TENSP,MOTA,GIABAN,GIANHAP,KICHTHUOC,DOTUOI,TRONGLUONG,MANCC,XUATXU,NGUOISUA) values(N'" + ma + "',N'" + ten + "','" + mota + "','" + giaban + "',N'" + gianhap + "','" + kichthuoc + "',N'" + dotuoi + "','" + trongluong + "','" + mancc + "',N'" + xx + "',N'" + nguoitao + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int updateDungCu(string ma, string ten, string mota, string giaban, string gianhap, string kichthuoc, string dotuoi, string trongluong, string mancc, string xx, string nguoitao)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Sanpham set TENSP = N'" + ten + "',MOTA= N'" + mota + "',GIABAN= N'" + giaban + "',GIANHAP= N'" + gianhap + "',KICHTHUOC= N'" + kichthuoc + "',DOTUOI= N'" + dotuoi + "',TRONGLUONG= N'" + trongluong + "',MANCC= N'" + mancc + "',XUATXU= N'" + xx + "',NGUOISUA= N'" + nguoitao + "' where masp='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
    }
}