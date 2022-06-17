using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
namespace web.Controllers
{
    public class DSSPController : Controller
    {
        //
        // GET: /DSSP/
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
        public ActionResult LOAIMATHANG(string id, int page = 1)
        {
            ViewBag.ID = id;
            var obj = new SANPHAM();
            var emp = obj.getDataLMH(page, 10, id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult LOAIMATHANG(string id, string doc, string ngang, string mua, int page = 1)
        {
            var obj = new SANPHAM();
            if (!string.IsNullOrEmpty(doc))
            {
                Session["doc"] = true;
                Session["ngang"] = false;
                var emp = obj.getDataLMH(page, 10, id);
                return View(emp);
            }
            if (!string.IsNullOrEmpty(ngang))
            {
                Session["ngang"] = true;
                Session["doc"] = false;
                var emp = obj.getDataLMH(page, 10, id);
                return View(emp);
            }
            if (!string.IsNullOrEmpty(mua))
            {
                if ((Boolean)Session["ngang"] == true)
                {
                    var emp = obj.getDataLMH(page, 10, id);
                    them(mua);
                    return View(emp);
                }
                if ((Boolean)Session["doc"] == true)
                {
                    var emp = obj.getDataLMH(page, 10, id);
                    them(mua);
                    return View(emp);
                }
            }
            return View();
        }
        public ActionResult CHUDE(string id, int page = 1)
        {
            ViewBag.ID = id;
            var obj = new SANPHAM();
            var emp = obj.getDataCD(page, 10, id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult CHUDE(string id, string doc, string ngang, string mua, int page = 1)
        {
            var obj = new SANPHAM();
            if (!string.IsNullOrEmpty(doc))
            {
                Session["doc"] = true;
                Session["ngang"] = false;
                var emp = obj.getDataCD(page, 10, id);
                return View(emp);
            }
            if (!string.IsNullOrEmpty(ngang))
            {
                Session["ngang"] = true;
                Session["doc"] = false;
                var emp = obj.getDataCD(page, 10, id);
                return View(emp);
            }
            if (!string.IsNullOrEmpty(mua))
            {
                if ((Boolean)Session["ngang"] == true)
                {
                    var emp = obj.getDataCD(page, 10, id);
                    them(mua);
                    return View(emp);
                }
                if ((Boolean)Session["doc"] == true)
                {
                    var emp = obj.getDataCD(page, 10, id);
                    them(mua);
                    return View(emp);
                }
            }
            return View();
        }
        public ActionResult LOAICHUDE(string id, int page = 1)
        {
            ViewBag.ID = id;
            var obj = new SANPHAM();
            var emp = obj.getDataLCD(page, 10, id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult LOAICHUDE(string id, string doc, string ngang, string mua, int page = 1)
        {
            var obj = new SANPHAM();
            if (!string.IsNullOrEmpty(doc))
            {
                Session["doc"] = true;
                Session["ngang"] = false;
                var emp = obj.getDataLCD(page, 10, id);
                return View(emp);
            }
            if (!string.IsNullOrEmpty(ngang))
            {
                Session["ngang"] = true;
                Session["doc"] = false;
                var emp = obj.getDataLCD(page, 10, id);
                return View(emp);
            }
            if (!string.IsNullOrEmpty(mua))
            {
                if ((Boolean)Session["ngang"] == true)
                {
                    var emp = obj.getDataLCD(page, 10, id);
                    them(mua);
                    return View(emp);
                }
                if ((Boolean)Session["doc"] == true)
                {
                    var emp = obj.getDataLCD(page, 10, id);
                    them(mua);
                    return View(emp);
                }
            }
            return View();
        }
    }
}
