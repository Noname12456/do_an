using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace web.Models
{
    public class BAOCAO
    {
        public string conf = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public string MASP { get; set; }
        public string TENSP { get; set; }
        public string SLTON { get; set; }
        public string SLNHAP { get; set; }
        public string SLNHAPKHAC { get; set; }
        public string SL_BAN { get; set; }
        public string SL_XUATKHAC { get; set; }
        public List<BAOCAO> getData3(string cn, string tungay, string dengay)
        {
            List<BAOCAO> listBH = new List<BAOCAO>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select SANPHAMCN.MASP,TENSP,SANPHAMCN.SLTON,nhap.sl_nhap,nhap_khac.sl_nhapkhac,phieu_ban.sl_ban,phieu_xuatk.sl_xuatk" +
" from sanpham" +
" INNER JOIN SANPHAMCN ON sanpham.MASP = SANPHAMCN.MASP " +
" LEFT JOIN (Select masp,sum(sl) as sl_nhap" +
" from PHIEUNHAP " +
" INNER JOIN PHIEUNHAPCT" +
" ON PHIEUNHAP.MAPHIEU = PHIEUNHAPCT.MAPHIEU " +
" where  macn = '" + cn + "' and NGAYNHAP <= '" + dengay + "' and PHIEUNHAP.LOAIPHIEU = 0 and PHIEUNHAP.TRANGTHAI = 1" +
" group by masp) as nhap ON nhap.MASP = SANPHAM.MASP" +
" LEFT JOIN (Select masp,sum(sl) as sl_nhapkhac" +
" from PHIEUNHAP" +
" INNER JOIN PHIEUNHAPCT" +
" ON PHIEUNHAP.MAPHIEU = PHIEUNHAPCT.MAPHIEU" +
" where macn = '" + cn + "' and NGAYNHAP <= '" + dengay + "'  and PHIEUNHAP.LOAIPHIEU = 1 and PHIEUNHAP.TRANGTHAI = 1" +
" group by masp) as nhap_khac ON nhap_khac.MASP = SANPHAM.MASP" +
" LEFT JOIN (Select masp,SUM(SL) as sl_ban" +
" from DONHANG" +
" INNER JOIN DONHANGCT" +
" ON DONHANG.MADH = DONHANGCT.MADH" +
" where  macn = '" + cn + "' and NGAYLAP <= '" + dengay + "' and (DONHANG.TRANGTHAI = 5 or  DONHANG.TRANGTHAI = 3)" +
" group by masp ) as phieu_ban on phieu_ban.MASP = SANPHAM.MASP" +
" LEFT JOIN (Select masp,sum(sl) as sl_xuatk" +
" from PHIEUXUAT" +
" INNER JOIN PHIEUXUATCT" +
" ON PHIEUXUAT.MAPHIEU = PHIEUXUATCT.MAPHIEU" +
" where MACNGUI = '" + cn + "' and NGAYXUAT <= '" + dengay + "' and PHIEUXUAT.TRANGTHAI = 6" +
" group by masp) as phieu_xuatk on phieu_xuatk.MASP = SANPHAM.MASP" +
" where  macn = '" + cn + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                BAOCAO emp = new BAOCAO();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.SLTON = dr.GetValue(2).ToString();
                emp.SLNHAP = dr.GetValue(3).ToString() != "" ? dr.GetValue(3).ToString() : "0";
                emp.SLNHAPKHAC = dr.GetValue(4).ToString() != "" ? dr.GetValue(4).ToString() : "0";
                emp.SL_BAN = dr.GetValue(5).ToString() != "" ? dr.GetValue(5).ToString() : "0";
                emp.SL_XUATKHAC = dr.GetValue(6).ToString() != "" ? dr.GetValue(6).ToString() : "0";
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
    }
}