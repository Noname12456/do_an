using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
namespace web.Controllers
{
    public class CHITIETSPController : Controller
    {
        //
        // GET: /CHITIETSP/

        public ActionResult CHITIETSP(string id)
        {
            SANPHAM sp = new SANPHAM();
            Session["CT"] = sp.getDataCT(id);
            return View();
        }
        [HttpPost]
        public ActionResult CHITIETSP(string id, string them, string mua, string sl)
        {
            if (!string.IsNullOrEmpty(them))
            {
                GIOHANG gh = new GIOHANG();
                if (sl == null)
                {
                    sl = "1";
                }
                if (Session["GH"] == null)
                {
                    Session["GH"] = gh.them(them, int.Parse(sl));
                }
                else
                {
                    var dt = Session["GH"] as List<GIOHANG>;
                    if (dt.Exists(t => t.ID == id))
                    {
                        foreach (var row in dt)
                        {
                            if (row.ID.Equals(them))
                            {
                                row.SL += int.Parse(sl);
                            }
                        }
                    }
                    else
                    {
                        var item = new GIOHANG();
                        item.ID = id;
                        item.SL = int.Parse(sl);
                        dt.Add(item);
                    }
                    Session["GH"] = dt;
                }
            }
            if (!string.IsNullOrEmpty(mua))
            {
                GIOHANG gh = new GIOHANG();
                if (sl == null)
                {
                    sl = "1";
                }
                if (Session["GH"] == null)
                {
                    Session["GH"] = gh.them(mua, int.Parse(sl));
                }
                else
                {
                    var dt = Session["GH"] as List<GIOHANG>;
                    if (dt.Exists(t => t.ID == id))
                    {
                        foreach (var row in dt)
                        {
                            if (row.ID.Equals(mua))
                            {
                                row.SL += int.Parse(sl);
                            }
                        }
                    }
                    else
                    {
                        var item = new GIOHANG();
                        item.ID = id;
                        item.SL = int.Parse(sl);
                        dt.Add(item);
                    }
                    Session["GH"] = dt;
                }
                return RedirectToAction("THANHTOAN", "THANHTOAN");
            }
            return View();
        }
    }
}
