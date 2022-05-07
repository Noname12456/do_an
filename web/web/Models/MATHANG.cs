using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace web.Models
{
    public class MATHANG
    {
        public string conf = "Data Source=KID;Initial Catalog=QL_NhaSach;User ID=sa";
        public string ID { get; set; }
        public string Ten { get; set; }
        public List<MATHANG> getData()
        {
            List<MATHANG> listBH = new List<MATHANG>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from MATHANG where disabled=0", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MATHANG emp = new MATHANG();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
    }
}