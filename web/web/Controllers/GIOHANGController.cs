using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using web.Models;

namespace web.Controllers
{
    public class GIOHANGController : Controller
    {
        //
        // GET: /GIOHANG/

        public ActionResult GIOHANG()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GIOHANG(string xoa)
        {
            if (!string.IsNullOrEmpty(xoa))
            {
                int dem = 0;
                List<GIOHANG> del = Session["GH"] as List<GIOHANG>;
                if (del != null)
                {
                    for (int i = 0; i < del.Count; i++)
                    {

                        if (del[i].ID == xoa)
                        {
                            del.RemoveAt(i);
                        }
                    }
                    foreach (var item in del)
                    {
                        dem++;
                    }
                    if (dem == 0)
                    {
                        Session["GH"] = null;
                    }
                }
            }
            return View();
        }
        public JsonResult Update(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<List<GIOHANG>>(cartModel);

            //ép kiểu từ session
            var sessionCart = (List<GIOHANG>)Session["GH"];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.Single(x => x.ID == item.ID);
                if (jsonItem != null)
                {
                    item.SL = jsonItem.SL;
                }
            }
            //cập nhật lại session
            Session["GH"] = sessionCart;

            return Json(new
            {
                status = true
            });
        }
    }
}
