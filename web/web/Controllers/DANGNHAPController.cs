using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
namespace web.Controllers
{
    public class DANGNHAPController : Controller
    {
        //
        // GET: /DANGNHAP/

        public ActionResult DANGKY()
        {
            if ((Boolean)Session["log"] == false)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Index");
            }
        }
        public ActionResult DoiMatKhau()
        {
            if ((Boolean)Session["log"] == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Index");
            }
        }
        public ActionResult DangXuat()
        {
            if ((Boolean)Session["log"] == true)
            {
                Session["log"] = false;
                Session["Email"] = null;
                Session["Ho"] = null;
                Session["Ten"] = null;
                Session["SDT"] = null;
                Session["GH"] = null;

            }
            return RedirectToAction("Index", "Index");
        }
        public ActionResult DangNhap()
        {
            if ((Boolean)Session["log"] == false)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Index");
            }
        }
        [HttpPost]
        public ActionResult Dangky(string ho, string ten, string SDT, string email, string matkhau, string them, string lmatkhau)
        {
            if (!string.IsNullOrEmpty(them))
            {
                if (matkhau.Length >= 5 && lmatkhau.Length >= 5)
                {
                    Session["Ho"] = ho;
                    Session["Ten"] = ten;
                    Session["SDT"] = SDT;
                    KHACHHANG kh = new KHACHHANG();
                    if (matkhau.Equals(lmatkhau))
                    {
                        int kq = kh.them(ho, ten, SDT, email, matkhau);
                        if (kq == -1)
                        {
                            ViewBag.TB = "Tài khoản đã có người đăng ký";
                        }
                        else if (kq == 0)
                        {
                            ViewBag.TB = "Đã xảy ra lỗi";
                        }
                        else
                        {
                            Session["log"] = true;
                            Session["Email"] = email;
                            return RedirectToAction("Index", "Index");
                        }
                    }
                    else
                    {
                        ViewBag.TB = "Mật khẩu không khớp";
                    }
                }
                else
                {
                    ViewBag.TB = "Mật khẩu phải từ 5 ký tự";
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string email, string matkhau, string them)
        {
            if (!string.IsNullOrEmpty(them))
            {
                KHACHHANG kh = new KHACHHANG();
                int kq = kh.getData(email, matkhau);
                if (kq == 0)
                {
                    ViewBag.TB = "Tài Khoản mật khẩu sai";
                }
                else
                {
                    Session["log"] = true;
                    Session["Email"] = email;
                    return RedirectToAction("Index", "Index");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult DoiMatKhau(string matkhaucu, string matkhaumoi, string matkhaulap,string doi)
        {
            if (!string.IsNullOrEmpty(doi))
            {
                KHACHHANG kh = new KHACHHANG();
                int kq = kh.getData(Session["Email"].ToString(), matkhaucu);
                if (kq == 0)
                {
                    ViewBag.TB = "Tài Khoản mật khẩu sai";
                }
                else
                {
                    if (matkhaumoi.Equals(matkhaulap))
                    {
                        kh.update(Session["Email"].ToString(), matkhaulap);
                        return RedirectToAction("Index", "Index");
                    }
                    else
                    {
                        ViewBag.TB = "Mật khẩu không khớp";
                    }
                    return View();
                }            
            }
            return View();
        }
    }
}
