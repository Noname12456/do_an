using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using web.Models;
namespace web.Controllers
{
    public class THANHTOANController : Controller
    {
        //
        // GET: /THANHTOAN/

        public ActionResult THANHTOAN()
        {
            if (Session["GH"] == null)
            {
                return RedirectToAction("Index", "Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult THANHTOAN(string thanhtoan, string km, string txt_km, string hoten, string email, string sdt, string tp, string qh, string ph, string td)
        {
            var hinhthuc = 0;
            if (!string.IsNullOrEmpty(km))
            {
                KHUYENMAI km1 = new KHUYENMAI();
                var menu = km1.getData(txt_km);
                int dem = 0;
                int tong = 0;
                var menu3 = Session["GH"] as List<GIOHANG>;
                foreach (var item in menu3)
                {
                    SANPHAM sp = new SANPHAM();
                    var menu2 = sp.getDataCT(item.ID);
                    foreach (var item2 in menu2)
                    {
                        int tt = item.SL * int.Parse(item2.GIABAN);
                        tong += tt;
                    }
                }
                foreach (var item in menu)
                {
                    dem++;
                    if (tong > int.Parse(item.DK))
                    {
                        if (DateTime.Parse(item.NGAYBD) <= DateTime.Now && DateTime.Parse(item.NGAYKT) >= DateTime.Now)
                        {
                            Session["HTKM"] = item.HINHTHUCKM;
                            Session["MAKHM"] = txt_km;
                            Session["KM"] = item.ST;
                            ViewBag.TT = item.ST;
                        }
                        if (DateTime.Parse(item.NGAYBD) > DateTime.Now)
                        {
                            ViewBag.TB = "Mã khuyến mãi bắt đầu từ ngày " + item.NGAYBD + " đến " + item.NGAYKT;
                        }
                        if (DateTime.Parse(item.NGAYKT) < DateTime.Now)
                        {
                            ViewBag.TB = "Mã khuyến mãi đã kết thúc từ ngày " + item.NGAYKT;
                        }
                    }
                    else
                    {
                        ViewBag.TB = "Đơn hàng chưa đủ điều kiện để áp dụng khuyến mãi";
                    }

                }
                if (dem == 0)
                {
                    ViewBag.TB = "Mã khuyến mãi không đúng";
                }
            }
            if (!string.IsNullOrEmpty(thanhtoan))
            {
                var tong = 0;
                float tg = 0;
                DONHANG hd = new DONHANG();
                if ((Boolean)Session["log"] == false)
                {
                    int kq = 0;
                    if (Session["KM"] != null)
                    {
                        kq = hd.them(hoten, email, sdt, td, ph, tp, qh, Session["MAKHM"].ToString());
                    }
                    else
                    {
                        kq = hd.them2(hoten, email, sdt, td, ph, tp, qh);
                    }

                    if (kq != 0)
                    {
                        var menu = Session["GH"] as List<GIOHANG>;
                        foreach (var item in menu)
                        {
                            SANPHAM sp = new SANPHAM();
                            var menu2 = sp.getDataCT(item.ID);
                            foreach (var item2 in menu2)
                            {
                                int tt = item.SL * int.Parse(item2.GIABAN);
                                tong += tt;
                                int kq1 = hd.CT(item.ID, item.SL, tt);
                                if (kq1 != 0)
                                {
                                    int kq3 = hd.update(item.ID);
                                    if (kq3 != 0)
                                    {
                                        Session["GH"] = null;
                                    }
                                }
                            }
                        }
                        if (Session["KM"] != null)
                        {
                            if (int.Parse(Session["HTKM"].ToString()) == 1)
                            {
                                tg = tong * (float.Parse(Session["KM"].ToString()) / 100);
                            }
                            else
                            {
                                tg = int.Parse(Session["KM"].ToString());
                            }
                            int kq4 = hd.update2(tg);
                        }
                        Session["KM"] = null;
                        var ma = hd.hd();
                        try
                        {
                            if (ModelState.IsValid)
                            {
                                var tongCT = 0;
                                SANPHAM sp = new SANPHAM();
                                var senderEmail = new MailAddress("leemy12456@gmail.com", "Lê Thị Trà My");
                                var receiverEmail = new MailAddress(email, hoten);
                                var password = "***mymymy***123123123";
                                var sub = "CẢM ƠN BẠN ĐÃ MUA HÀNG Ở NHÀ SÁCH MAHD: " + ma;
                                var body = "<div class='text-center'>" +
                                 "<h1>DANH SÁCH SẢN PHẨM</h1>";
                                body += "<table class='table'>";
                                var menuCT = hd.getData2(ma.ToString());
                                foreach (var item in menuCT)
                                {
                                    body += "<tr><td></td><td>Tên sp</td><td>Giá</td><td>SL</td><td>Thành tiền</td></tr>";
                                    body += "<tr> <td>";
                                    var menu2 = sp.getDataCT(item.masp);
                                    foreach (var item2 in menu2)
                                    {
                                        var thanhtien = int.Parse(item2.GIABAN) * int.Parse(item.sl);
                                        tongCT += thanhtien;
                                        SANPHAMHINHANH SPH = new SANPHAMHINHANH();
                                        var sanPhamHinh = SPH.getData(item2.MASP);
                                        foreach (var itemHinh in sanPhamHinh)
                                        {
                                            var hinh = "/IMG/" + itemHinh.HINH;
                                            body += "<img src=cid:" + hinh + " style='width:120px;height:120px' />";
                                        }
                                        body += "</td>" +
                                            "<td>" + item2.TENSP + "</td>" +
                                           "<td>" +
                                              item2.GIABAN +
                                          " </td>" +
                                           "<td>" +
                                              item.sl +
                                           "</td>" +
                                            "<td>" +
                                               thanhtien + "VND" +
                                           "</td>" +
                                       "</tr>";
                                    }
                                }
                                body += "<tr>" +
                                            "<td colspan='3'>Tổng cộng</td>" +
                                            "<td> " + tongCT + " </td>" +
                                        "</tr> </table> </div>";
                                var smtp = new SmtpClient
                                {
                                    Host = "smtp.gmail.com",
                                    Port = 587,
                                    EnableSsl = true,
                                    DeliveryMethod = SmtpDeliveryMethod.Network,
                                    UseDefaultCredentials = false,
                                    Credentials = new NetworkCredential(senderEmail.Address, password)
                                };
                                using (MailMessage mess = new MailMessage(senderEmail, receiverEmail)
                                {
                                    Subject = sub,
                                    Body = body,
                                    IsBodyHtml = true
                                })
                                {
                                    smtp.Send(mess);
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                        return RedirectToAction("HOADON", "HOADON");
                    }
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
                    int kq = 0;
                    if (Session["KM"] != null)
                    {
                        kq = hd.themKH(ma, hoten, email, sdt, td, ph, tp, qh, Session["MAKHM"].ToString());
                    }
                    else
                    {
                        kq = hd.themKH2(ma, hoten, email, sdt, td, ph, tp, qh);
                    }
                    if (kq != 0)
                    {
                        var menu = Session["GH"] as List<GIOHANG>;
                        foreach (var item in menu)
                        {
                            SANPHAM sp = new SANPHAM();
                            var menu2 = sp.getDataCT(item.ID);
                            foreach (var item2 in menu2)
                            {
                                int tt = item.SL * int.Parse(item2.GIABAN);
                                tong += tt;
                                int kq1 = hd.CT(item.ID, item.SL, tt);
                                if (kq1 != 0)
                                {
                                    int kq3 = hd.update(item.ID);
                                    if (kq3 != 0)
                                    {
                                        Session["GH"] = null;
                                    }
                                }
                            }
                        }
                        if (Session["KM"] != null)
                        {
                            if (int.Parse(Session["HTKM"].ToString()) == 1)
                            {
                                tg = tong * (float.Parse(Session["KM"].ToString()) / 100);
                            }
                            else
                            {
                                tg = int.Parse(Session["KM"].ToString());
                            }
                            int kq4 = hd.update2(tg);
                        }
                        Session["KM"] = null;
                        var ma2 = hd.hd();
                        try
                        {
                            if (ModelState.IsValid)
                            {
                                var tongCT = 0;
                                SANPHAM sp = new SANPHAM();
                                var senderEmail = new MailAddress("leemy12456@gmail.com", "Lê Thị Trà My");
                                var receiverEmail = new MailAddress(email, hoten);
                                var password = "***mymymy***123123123";
                                var sub = "CẢM ƠN BẠN ĐÃ MUA HÀNG Ở NHÀ SÁCH MAHD: " + ma;
                                var body = "<div class='text-center'>" +
                                 "<h1>DANH SÁCH SẢN PHẨM</h1>";
                                body += "<table class='table'>";
                                var menuCT = hd.getData2(ma.ToString());
                                foreach (var item in menuCT)
                                {
                                    body += "<tr><td></td><td>Tên sp</td><td>Giá</td><td>SL</td><td>Thành tiền</td></tr>";
                                    body += "<tr> <td>";
                                    var menu2 = sp.getDataCT(item.masp);
                                    foreach (var item2 in menu2)
                                    {
                                        var thanhtien = int.Parse(item2.GIABAN) * int.Parse(item.sl);
                                        tongCT += thanhtien;
                                        SANPHAMHINHANH SPH = new SANPHAMHINHANH();
                                        var sanPhamHinh = SPH.getData(item2.MASP);
                                        foreach (var itemHinh in sanPhamHinh)
                                        {
                                            var hinh = "/IMG/" + itemHinh.HINH;
                                            body += "<img src=cid:" + hinh + " style='width:120px;height:120px' />";
                                        }
                                        body += "</td>" +
                                            "<td>" + item2.TENSP + "</td>" +
                                           "<td>" +
                                              item2.GIABAN +
                                          " </td>" +
                                           "<td>" +
                                              item.sl +
                                           "</td>" +
                                            "<td>" +
                                               thanhtien + "VND" +
                                           "</td>" +
                                       "</tr>";
                                    }
                                }
                                body += "<tr>" +
                                            "<td colspan='3'>Tổng cộng</td>" +
                                            "<td> " + tongCT + " </td>" +
                                        "</tr> </table> </div>";
                                var smtp = new SmtpClient
                                {
                                    Host = "smtp.gmail.com",
                                    Port = 587,
                                    EnableSsl = true,
                                    DeliveryMethod = SmtpDeliveryMethod.Network,
                                    UseDefaultCredentials = false,
                                    Credentials = new NetworkCredential(senderEmail.Address, password)
                                };
                                using (MailMessage mess = new MailMessage(senderEmail, receiverEmail)
                                {
                                    Subject = sub,
                                    Body = body,
                                    IsBodyHtml = true
                                })
                                {
                                    smtp.Send(mess);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            
                        }
                    }
                    return RedirectToAction("HOADON", "HOADON");
                }
            }
            return View();
        }

    }
}
