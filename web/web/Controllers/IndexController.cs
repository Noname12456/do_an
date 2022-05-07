using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
namespace web.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/
        void them(string id)
        {
            GIOHANG gh = new GIOHANG();
            if (Session["GH"] == null)
            {
                Session["GH"] = gh.them(id, 1);
            }
            else
            {
                var dt = Session["GH"] as List<GIOHANG>;
                if (dt.Exists(t => t.ID == id))
                {
                    foreach (var row in dt)
                    {
                        if (row.ID.Equals(id))
                        {
                            row.SL += 1;
                        }
                    }
                }
                else
                {
                    var item = new GIOHANG();
                    item.ID = id;
                    item.SL = 1;
                    dt.Add(item);
                }
                Session["GH"] = dt;
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string mua)
        {
            them(mua);
            return View();
        }
        public ActionResult TIMKIEM()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TIMKIEM(string mua)
        {
            them(mua);
            return View();
        }
    }
}
