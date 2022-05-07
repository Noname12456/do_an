using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
namespace web.Controllers
{
    public class HOADONController : Controller
    {
        //
        // GET: /HOADON/

        public ActionResult HOADON()
        {
            return View();
        }
        public ActionResult CTHOADON(string id)
        {
            DONHANG hd = new DONHANG();
            Session["CT"] = hd.getData2(id);
            return View();
        }
        public ActionResult HTHOADON()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CTHOADON(string id, string huy)
        {
            DONHANG hd = new DONHANG();
            hd.update3(huy);
            var ch = "CTHOADON/" + id;
            return RedirectToAction(ch, "HOADON");
        }
        [HttpPost]
        public ActionResult HTHOADON(string Search)
        {
            if ((Boolean)Session["log"] == false)
            {
                DONHANG hd = new DONHANG();
                Session["HD"] = hd.getData(Search);
            }
            else
            {
                KHACHHANG m = new KHACHHANG();
                var kh = m.getData(Session["Email"].ToString());
                int ma = 0;
                foreach (var item in kh)
                {
                    ma = item.ID;
                }
                DONHANG hd = new DONHANG();
                Session["HD"] = hd.getData(Search, ma);
            }
            return View();
        }
    }
}
