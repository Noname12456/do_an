using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class GIOHANG
    {
        public string ID { get; set; }
        public int SL { get; set; }
        public List<GIOHANG> them(string id, int sl)
        {
            List<GIOHANG> listBH = new List<GIOHANG>();
            GIOHANG emp = new GIOHANG();
            emp.ID = id;
            emp.SL = sl;
            listBH.Add(emp);
            return listBH;
        }
    }
}