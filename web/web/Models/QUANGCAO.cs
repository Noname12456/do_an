using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class QUANGCAO
    {
        public string conf = "Data Source=KID;Initial Catalog=QL_NhaSach;User ID=sa";
        public string ID { get; set; }
        public string Ten { get; set; }
        public List<QUANGCAO> getData()
        {
            List<QUANGCAO> listBH = new List<QUANGCAO>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from QUANGCAO where disabled=0", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                QUANGCAO emp = new QUANGCAO();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
    }
}