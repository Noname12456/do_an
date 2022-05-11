using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class PHIEUNHAPCT
    {
        public string conf = "Data Source=LAPTOP-G07FAD75;Initial Catalog=QL_NhaSach;User ID=sa";
        public string MASP { get; set; }
        public string MAPHIEU { get; set; }
        public string SL { get; set; }
        public string DG { get; set; }
        public string DGVAT { get; set; }
        public string TT { get; set; }
        public string TTVAT { get; set; }
        public List<PHIEUNHAPCT> getData(string ma)
        {
            List<PHIEUNHAPCT> listBH = new List<PHIEUNHAPCT>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from PHIEUNHAPCT where maphieu='" + ma + "' and disabled = 0", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PHIEUNHAPCT emp = new PHIEUNHAPCT();
                emp.MAPHIEU = dr.GetValue(0).ToString();
                emp.MASP = dr.GetValue(1).ToString();
                emp.SL = dr.GetValue(2).ToString();
                emp.DG = dr.GetValue(5).ToString();
                emp.DGVAT = dr.GetValue(6).ToString();
                emp.TT = dr.GetValue(3).ToString();
                emp.TTVAT = dr.GetValue(4).ToString();      
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
    }
}