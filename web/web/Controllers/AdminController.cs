using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using web.Models;
namespace web.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult Admin()
        {
            if ((Boolean)Session["logad"] == true)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult AdminHome()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult SACH()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult DUNGCU()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult LOAIMH()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult CHUDE()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult LOAICD()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult KHUYENMAI()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult DONHANG()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult DANGXUAT()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            Session["logad"] = false;
            Session["maad"] = null;
            return RedirectToAction("Admin", "Admin");
        }
        public ActionResult CTHOADON(string id)
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            DONHANG hd = new DONHANG();
            Session["CT"] = hd.getData2(id);
            return View();
        }
        public ActionResult TACGIA()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult NHANVIEN()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult NHAXUATBAN()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult NHACUNGCAP()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult CHINHANH()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult NHACUNGCAPNHAP()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult PHIEUNHAP()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult DSPHIEUNHAP()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult SPCHINHANH2(string id)
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            Session["CTSPCN"] = id;
            return View();
        }
        public ActionResult CNPHIEUNHAP(string id)
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            Session["PN"] = id;
            return View();
        }
        public ActionResult CTPHIEUNHAP(string id)
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            Session["PN"] = id;
            return View();
        }
        public ActionResult QUYEN()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult LOAIQUYEN()
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            return View();
        }
        public ActionResult LOAIQUYENOFQUYEN(string id)
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            Session["LOAIQUYEN"] = id;
            return View();
        }
        public ActionResult LOAIQUYENOFNHANVIEN(string id,string manv)
        {
            if ((Boolean)Session["logad"] == false)
            {
                return RedirectToAction("Admin", "Admin");
            }
            Session["LOAIQUYENOFNHANVIEN"] = id;
            Session["manv"] = manv;
            return View();
        }
        [HttpPost]
        public ActionResult CTHOADON(string id, string xn, string gh, string huy, string nh, string knh, string xnhuy,string cn)
        {
            DONHANG hd = new DONHANG();
            var maad = "";
            if ((Boolean)Session["logad"] == true)
            {
                maad = Session["maad"].ToString(); ;
            }
            if (!string.IsNullOrEmpty(xn))
            {
                hd.update4(xn);
            }
            if (!string.IsNullOrEmpty(gh))
            {
               var kq = hd.update5(gh, cn, Session["CT"] as List<DONHANG>);
               if (kq == false)
               {
                   Session["erro"] = "Sản phẩm không có trong chi nhánh hoặc không còn tồn kho";
               }
            }
            if (!string.IsNullOrEmpty(huy))
            {
                hd.update6(huy);
            }
            if (!string.IsNullOrEmpty(nh))
            {
                hd.update7(nh);
            }
            if (!string.IsNullOrEmpty(knh))
            {
                hd.update8(knh, cn, Session["CT"] as List<DONHANG>);
            }
            if (!string.IsNullOrEmpty(xnhuy))
            {
                hd.update6(xnhuy);
            }
            return RedirectToAction("CTHOADON", "Admin");
        }
        [HttpPost]
        public ActionResult DSPHIEUNHAP(string Huy, string Duyet)
        {
            PHIEUNHAP hd = new PHIEUNHAP();
            var maad = "";
            if ((Boolean)Session["logad"] == true)
            {
                maad = Session["maad"].ToString(); ;
            }
            if (!string.IsNullOrEmpty(Huy))
            {
                hd.update1(Huy, maad);
            }
            if (!string.IsNullOrEmpty(Duyet))
            {
                hd.update2(Duyet, maad);
            }
            return RedirectToAction("DSPHIEUNHAP", "Admin");
        }
        [HttpPost]
        public ActionResult Admin(string them, string email, string matkhau)
        {
            if (!string.IsNullOrEmpty(them))
            {
                NHANVIEN kh = new NHANVIEN();
                int kq = kh.getData(email, matkhau);
                if (kq == 0)
                {
                    ViewBag.TB = "Tài Khoản mật khẩu sai";
                }
                else
                {
                    Session["logad"] = true;
                    Session["maad"] = email;
                    return RedirectToAction("AdminHome", "Admin");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult SACH(string xoa, string phuchoi)
        {
            SANPHAM sp = new SANPHAM();
            if (!string.IsNullOrEmpty(xoa))
            {
                sp.update3(xoa);
            }
            if (!string.IsNullOrEmpty(phuchoi))
            {
                sp.update4(phuchoi);
            }
            return View();
        }
        [HttpPost]
        public ActionResult DUNGCU(string xoa, string phuchoi)
        {
            SANPHAM sp = new SANPHAM();
            if (!string.IsNullOrEmpty(xoa))
            {
                sp.update3(xoa);
            }
            if (!string.IsNullOrEmpty(phuchoi))
            {
                sp.update4(phuchoi);
            }
            return View();
        }
        [HttpPost]
        public ActionResult NHANVIEN(string xoa, string phuchoi)
        {
            NHANVIEN sp = new NHANVIEN();
            if (!string.IsNullOrEmpty(xoa))
            {
                sp.update3(xoa);
            }
            if (!string.IsNullOrEmpty(phuchoi))
            {
                sp.update4(phuchoi);
            }
            return View();
        }
        [HttpPost]
        public ActionResult KHUYENMAI(string xoa, string phuchoi)
        {
            KHUYENMAI sp = new KHUYENMAI();
            if (!string.IsNullOrEmpty(xoa))
            {
                sp.update3(xoa);
            }
            if (!string.IsNullOrEmpty(phuchoi))
            {
                sp.update4(phuchoi);
            }
            return View();
        }
        public JsonResult THEMSACH(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MASP = jsonCart["MASP"];
            var TENSP = jsonCart["TENSP"];
            var MOTA = jsonCart["MOTA"];
            var GIABAN = jsonCart["GIABAN"];
            var GIANHAP = jsonCart["GIANHAP"];
            var KICHTHUOC = jsonCart["KICHTHUOC"];
            var SOTRANG = jsonCart["SOTRANG"];
            var DOTUOI = jsonCart["DOTUOI"];
            var TRONGLUONG = jsonCart["TRONGLUONG"];
            var TACGIA = jsonCart["TACGIA"];
            var HINH = jsonCart["HINH"];
            var NCC = jsonCart["NCC"];
            var NXB = jsonCart["NXB"];
            var NN = jsonCart["NN"];
            var XX = jsonCart["XX"];
            var LOAICD = jsonCart["LOAICD"];
            var nguoitao = Session["maad"].ToString();

            SANPHAM Sp = new SANPHAM();
            var ktraMa = Sp.KtraSp(MASP);
            if (ktraMa == 0)
            {
                var them = Sp.themSach(MASP, TENSP, MOTA, GIABAN, GIANHAP, KICHTHUOC, SOTRANG, DOTUOI, TRONGLUONG, NCC, NXB, NN, XX, nguoitao);
                if (them == 1)
                {
                    foreach (var item in TACGIA)
                    {
                        Sp.SachTG(MASP, item, nguoitao);
                    }
                    foreach (var item in LOAICD)
                    {
                        Sp.SanPhamLCD(MASP, item, nguoitao);
                    }
                    foreach (var item in HINH)
                    {
                        Sp.SanPhamHINH(MASP, item, nguoitao);
                    }
                    foreach (var item in TACGIA)
                    {
                        var ma = item;
                    }
                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        erro = "Đã xảy ra lỗi"
                    });
                }

            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Mã sách đã tồn tại"
                });
            }
        }
        [HttpPost]
        public ActionResult UploadFiles()
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {

                        HttpPostedFileBase file = files[i];
                        string fname;

                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        fname = Path.Combine(Server.MapPath("~/IMG/"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
        public JsonResult CHITIETSACH(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            string MASP = jsonCart["id"];

            SANPHAM Sp = new SANPHAM();
            var sanpham = Sp.getDataCT(MASP);
            TACGIA TG = new TACGIA();
            var SpTG = TG.getData2(MASP);
            SANPHAMCD spcd = new SANPHAMCD();
            var menuspcd = spcd.getData(MASP);
            SANPHAMHINHANH SPH2 = new SANPHAMHINHANH();
            var sanPhamHinh2 = SPH2.getData2(MASP);
            return Json(new
            {
                status = true,
                data = sanpham,
                dataTG = SpTG,
                dataCD = menuspcd,
                dataHinh = sanPhamHinh2
            });
        }
        public JsonResult XOAANH(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            int mahinh = jsonCart["id"];
            string masp = jsonCart["masp"];
            SANPHAMHINHANH sp = new SANPHAMHINHANH();
            sp.Delete(mahinh);
            var sanPhamHinh2 = sp.getData2(masp);
            return Json(new
            {
                status = true,
                dataHinh = sanPhamHinh2
            });
        }
        public JsonResult PHUCHOI(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            int mahinh = jsonCart["id"];
            string masp = jsonCart["masp"];
            SANPHAMHINHANH sp = new SANPHAMHINHANH();
            sp.PHUCHOI(mahinh);
            var sanPhamHinh2 = sp.getData2(masp);
            return Json(new
            {
                status = true,
                dataHinh = sanPhamHinh2
            });
        }
        public JsonResult UPDATESACH(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MASP = jsonCart["MASP"];
            var TENSP = jsonCart["TENSP"];
            var MOTA = jsonCart["MOTA"];
            var GIABAN = jsonCart["GIABAN"];
            var GIANHAP = jsonCart["GIANHAP"];
            var KICHTHUOC = jsonCart["KICHTHUOC"];
            var SOTRANG = jsonCart["SOTRANG"];
            var DOTUOI = jsonCart["DOTUOI"];
            var TRONGLUONG = jsonCart["TRONGLUONG"];
            var TACGIA = jsonCart["TACGIA"];
            var HINH = jsonCart["HINH"];
            var NCC = jsonCart["NCC"];
            var NXB = jsonCart["NXB"];
            var NN = jsonCart["NN"];
            var XX = jsonCart["XX"];
            var LOAICD = jsonCart["LOAICD"];
            var nguoitao = Session["maad"].ToString();

            SANPHAM Sp = new SANPHAM();
            var them = Sp.updateSach(MASP, TENSP, MOTA, GIABAN, GIANHAP, KICHTHUOC, SOTRANG, DOTUOI, TRONGLUONG, NCC, NXB, NN, XX, nguoitao);
            if (them == 1)
            {
                Sp.updateTgKhoa(MASP);
                TACGIA tg = new TACGIA();
                foreach (var item in TACGIA)
                {
                    if (tg.ktra(MASP, item) == 0)
                    {
                        Sp.SachTG(MASP, item, nguoitao);
                    }
                    else
                    {
                        Sp.updateTgMo(MASP, item);
                    }

                }
                Sp.updateLcdKhoa(MASP);
                SANPHAMCD spcd = new SANPHAMCD();
                foreach (var item in LOAICD)
                {
                    if (spcd.ktra(MASP, item) == 0)
                    {
                        Sp.SanPhamLCD(MASP, item, nguoitao);
                    }
                    else
                    {
                        Sp.updatelcdMo(MASP, item);
                    }
                }
                foreach (var item in HINH)
                {
                    Sp.SanPhamHINH(MASP, item, nguoitao);
                }
                //foreach (var item in TACGIA)
                //{
                //    var ma = item;
                //}
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Đã xảy ra lỗi"
                });
            }
        }
        public JsonResult THEMDUNGCU(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MASP = jsonCart["MASP"];
            var TENSP = jsonCart["TENSP"];
            var MOTA = jsonCart["MOTA"];
            var GIABAN = jsonCart["GIABAN"];
            var GIANHAP = jsonCart["GIANHAP"];
            var KICHTHUOC = jsonCart["KICHTHUOC"];
            var DOTUOI = jsonCart["DOTUOI"];
            var TRONGLUONG = jsonCart["TRONGLUONG"];
            var HINH = jsonCart["HINH"];
            var NCC = jsonCart["NCC"];
            var XX = jsonCart["XX"];
            var LOAICD = jsonCart["LOAICD"];
            var nguoitao = Session["maad"].ToString();

            SANPHAM Sp = new SANPHAM();
            var ktraMa = Sp.KtraSp(MASP);
            if (ktraMa == 0)
            {
                var them = Sp.themDungCu(MASP, TENSP, MOTA, GIABAN, GIANHAP, KICHTHUOC, DOTUOI, TRONGLUONG, NCC, XX, nguoitao);
                if (them == 1)
                {
                    foreach (var item in LOAICD)
                    {
                        Sp.SanPhamLCD(MASP, item, nguoitao);
                    }
                    foreach (var item in HINH)
                    {
                        Sp.SanPhamHINH(MASP, item, nguoitao);
                    }
                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        erro = "Đã xảy ra lỗi"
                    });
                }

            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Mã dụng cụ đã tồn tại"
                });
            }
        }
        public JsonResult UPDATEDUNGCU(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MASP = jsonCart["MASP"];
            var TENSP = jsonCart["TENSP"];
            var MOTA = jsonCart["MOTA"];
            var GIABAN = jsonCart["GIABAN"];
            var GIANHAP = jsonCart["GIANHAP"];
            var KICHTHUOC = jsonCart["KICHTHUOC"];
            var DOTUOI = jsonCart["DOTUOI"];
            var TRONGLUONG = jsonCart["TRONGLUONG"];
            var HINH = jsonCart["HINH"];
            var NCC = jsonCart["NCC"];
            var XX = jsonCart["XX"];
            var LOAICD = jsonCart["LOAICD"];
            var nguoitao = Session["maad"].ToString();

            SANPHAM Sp = new SANPHAM();
            var them = Sp.updateDungCu(MASP, TENSP, MOTA, GIABAN, GIANHAP, KICHTHUOC, DOTUOI, TRONGLUONG, NCC, XX, nguoitao);
            if (them == 1)
            {
                Sp.updateLcdKhoa(MASP);
                SANPHAMCD spcd = new SANPHAMCD();
                foreach (var item in LOAICD)
                {
                    if (spcd.ktra(MASP, item) == 0)
                    {
                        Sp.SanPhamLCD(MASP, item, nguoitao);
                    }
                    else
                    {
                        Sp.updatelcdMo(MASP, item);
                    }
                }
                foreach (var item in HINH)
                {
                    Sp.SanPhamHINH(MASP, item, nguoitao);
                }
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Đã xảy ra lỗi"
                });
            }
        }
        public JsonResult THEMLOAIMH(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var TEN = jsonCart["TEN"];
            var MH = jsonCart["MH"];
            var nguoitao = Session["maad"].ToString();

            LOAIMATHANG Sp = new LOAIMATHANG();
            var ktraMa = Sp.getData2(MA);
            if (ktraMa == 0)
            {
                var them = Sp.themLoaiMH(MA, TEN, MH, nguoitao);
                if (them == 1)
                {
                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        erro = "Đã xảy ra lỗi"
                    });
                }
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Mã Loại Mặt Hàng đã tồn tại"
                });
            }
        }
        public JsonResult UPDATELOAIMH(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var TEN = jsonCart["TEN"];
            var MH = jsonCart["MH"];
            var nguoitao = Session["maad"].ToString();

            LOAIMATHANG Sp = new LOAIMATHANG();
            var them = Sp.updateMH(MA, TEN, MH, nguoitao);
            if (them == 1)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Đã xảy ra lỗi"
                });
            }
        }
        public JsonResult ChiTietMH(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            string MA = jsonCart["id"];

            LOAIMATHANG Sp = new LOAIMATHANG();
            var mh = Sp.getData3(MA);
            return Json(new
            {
                status = true,
                data = mh,
            });
        }
        public JsonResult THEMCHUDE(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var TEN = jsonCart["TEN"];
            var LMH = jsonCart["LMH"];
            var nguoitao = Session["maad"].ToString();

            CHUDE Sp = new CHUDE();
            var ktraMa = Sp.getData3(MA);
            if (ktraMa == 0)
            {
                var them = Sp.themCD(MA, TEN, LMH, nguoitao);
                if (them == 1)
                {
                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        erro = "Đã xảy ra lỗi"
                    });
                }
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Mã Loại Mặt Hàng đã tồn tại"
                });
            }
        }
        public JsonResult UPDATECHUDE(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var TEN = jsonCart["TEN"];
            var MH = jsonCart["LMH"];
            var nguoitao = Session["maad"].ToString();

            CHUDE Sp = new CHUDE();
            var them = Sp.updateCD(MA, TEN, MH, nguoitao);
            if (them == 1)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Đã xảy ra lỗi"
                });
            }
        }
        public JsonResult ChiTietCD(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            string MA = jsonCart["id"];

            CHUDE Sp = new CHUDE();
            var mh = Sp.getData4(MA);
            return Json(new
            {
                status = true,
                data = mh,
            });
        }
        public JsonResult THEMLOAICHUDE(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var TEN = jsonCart["TEN"];
            var LMH = jsonCart["CD"];
            var nguoitao = Session["maad"].ToString();

            LOAICHUDE Sp = new LOAICHUDE();
            var ktraMa = Sp.getData6(MA);
            if (ktraMa == 0)
            {
                var them = Sp.themLCD(MA, TEN, LMH, nguoitao);
                if (them == 1)
                {
                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        erro = "Đã xảy ra lỗi"
                    });
                }
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Mã Loại Mặt Hàng đã tồn tại"
                });
            }
        }
        public JsonResult UPDATELOAICHUDE(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var TEN = jsonCart["TEN"];
            var MH = jsonCart["CD"];
            var nguoitao = Session["maad"].ToString();

            LOAICHUDE Sp = new LOAICHUDE();
            var them = Sp.updateLCD(MA, TEN, MH, nguoitao);
            if (them == 1)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Đã xảy ra lỗi"
                });
            }
        }
        public JsonResult ChiTietLCD(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            string MA = jsonCart["id"];

            LOAICHUDE Sp = new LOAICHUDE();
            var mh = Sp.getData7(MA);
            return Json(new
            {
                status = true,
                data = mh,
            });
        }
        public JsonResult THEMKM(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var gia = jsonCart["gia"];
            var dk = jsonCart["dk"];
            var HTKM = jsonCart["HTKM"];
            var ngaybd = jsonCart["ngaybd"];
            var ngayket = jsonCart["ngayket"];
            var nguoitao = Session["maad"].ToString();

            KHUYENMAI Sp = new KHUYENMAI();
            var ktraMa = Sp.getData6(MA);
            if (ktraMa == 0)
            {
                var them = Sp.them(MA, gia, dk, HTKM, ngaybd, ngayket, nguoitao);
                if (them == 1)
                {
                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        erro = "Đã xảy ra lỗi"
                    });
                }
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Mã KM đã tồn tại"
                });
            }
        }
        public JsonResult UPDATEKM(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var gia = jsonCart["gia"];
            var dk = jsonCart["dk"];
            var HTKM = jsonCart["HTKM"];
            var ngaybd = jsonCart["ngaybd"];
            var ngayket = jsonCart["ngayket"];
            var nguoitao = Session["maad"].ToString();

            KHUYENMAI Sp = new KHUYENMAI();
            var them = Sp.updateKM(MA, gia, dk, HTKM, ngaybd, ngayket, nguoitao);
            if (them == 1)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Đã xảy ra lỗi"
                });
            }
        }
        public JsonResult ChiTietKM(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            string MA = jsonCart["id"];

            KHUYENMAI Sp = new KHUYENMAI();
            var mh = Sp.getData(MA);
            return Json(new
            {
                status = true,
                data = mh,
            });
        }
        public JsonResult THEMTG(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var dc = jsonCart["dc"];
            var sdt = jsonCart["sdt"];
            var mota = jsonCart["mota"];
            var gt = jsonCart["gt"];
            var ten = jsonCart["ten"];
            var nguoitao = Session["maad"].ToString();

            TACGIA Sp = new TACGIA();
            var ktraMa = Sp.ktra2(MA);
            if (ktraMa == 0)
            {
                var them = Sp.them(MA, ten, dc, sdt, mota, gt, nguoitao);
                if (them == 1)
                {
                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        erro = "Đã xảy ra lỗi"
                    });
                }
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Mã TG đã tồn tại"
                });
            }
        }
        public JsonResult ChiTietTG(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            string MA = jsonCart["id"];

            TACGIA Sp = new TACGIA();
            var mh = Sp.getData3(MA);
            return Json(new
            {
                status = true,
                data = mh,
            });
        }
        public JsonResult UPDATETG(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var dc = jsonCart["dc"];
            var sdt = jsonCart["sdt"];
            var mota = jsonCart["mota"];
            var gt = jsonCart["gt"];
            var ten = jsonCart["ten"];
            var nguoitao = Session["maad"].ToString();

            TACGIA Sp = new TACGIA();
            var them = Sp.update(MA, ten, dc, sdt, mota, gt, nguoitao);
            if (them == 1)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Đã xảy ra lỗi"
                });
            }
        }
        public JsonResult THEMNXB(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var dc = jsonCart["dc"];
            var sdt = jsonCart["sdt"];
            var mota = jsonCart["mota"];
            var gt = jsonCart["gt"];
            var ten = jsonCart["ten"];
            var nguoitao = Session["maad"].ToString();

            NXB Sp = new NXB();
            var ktraMa = Sp.ktra2(MA);
            if (ktraMa == 0)
            {
                var them = Sp.them(MA, ten, dc, sdt, mota, gt, nguoitao);
                if (them == 1)
                {
                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        erro = "Đã xảy ra lỗi"
                    });
                }
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Mã TG đã tồn tại"
                });
            }
        }
        public JsonResult ChiTietNXB(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            string MA = jsonCart["id"];

            NXB Sp = new NXB();
            var mh = Sp.getData3(MA);
            return Json(new
            {
                status = true,
                data = mh,
            });
        }
        public JsonResult UPDATENXB(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var dc = jsonCart["dc"];
            var sdt = jsonCart["sdt"];
            var mota = jsonCart["mota"];
            var gt = jsonCart["gt"];
            var ten = jsonCart["ten"];
            var nguoitao = Session["maad"].ToString();

            NXB Sp = new NXB();
            var them = Sp.update(MA, ten, dc, sdt, mota, gt, nguoitao);
            if (them == 1)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Đã xảy ra lỗi"
                });
            }
        }
        public JsonResult THEMNCC(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var dc = jsonCart["dc"];
            var sdt = jsonCart["sdt"];
            var mota = jsonCart["mota"];
            var gt = jsonCart["gt"];
            var ten = jsonCart["ten"];
            var nguoitao = Session["maad"].ToString();

            NHACC Sp = new NHACC();
            var ktraMa = Sp.ktra2(MA);
            if (ktraMa == 0)
            {
                var them = Sp.them(MA, ten, dc, sdt, mota, gt, nguoitao);
                if (them == 1)
                {
                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        erro = "Đã xảy ra lỗi"
                    });
                }
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Mã TG đã tồn tại"
                });
            }
        }
        public JsonResult ChiTietNCC(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            string MA = jsonCart["id"];

            NHACC Sp = new NHACC();
            var mh = Sp.getData3(MA);
            return Json(new
            {
                status = true,
                data = mh,
            });
        }
        public JsonResult UPDATENCC(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var dc = jsonCart["dc"];
            var sdt = jsonCart["sdt"];
            var mota = jsonCart["mota"];
            var gt = jsonCart["gt"];
            var ten = jsonCart["ten"];
            var nguoitao = Session["maad"].ToString();

            NHACC Sp = new NHACC();
            var them = Sp.update(MA, ten, dc, sdt, mota, gt, nguoitao);
            if (them == 1)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Đã xảy ra lỗi"
                });
            }
        }
        public JsonResult THEMCN(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var dc = jsonCart["dc"];
            var sdt = jsonCart["sdt"];
            var mota = jsonCart["mota"];
            var gt = jsonCart["gt"];
            var ten = jsonCart["ten"];
            var nguoitao = Session["maad"].ToString();

            CHINHANH Sp = new CHINHANH();
            var ktraMa = Sp.ktra2(MA);
            if (ktraMa == 0)
            {
                var them = Sp.them(MA, ten, dc, sdt, mota, gt, nguoitao);
                if (them == 1)
                {
                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        erro = "Đã xảy ra lỗi"
                    });
                }
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Mã TG đã tồn tại"
                });
            }
        }
        public JsonResult ChiTietCN(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            string MA = jsonCart["id"];

            CHINHANH Sp = new CHINHANH();
            var mh = Sp.getData3(MA);
            return Json(new
            {
                status = true,
                data = mh,
            });
        }
        public JsonResult UPDATECN(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var dc = jsonCart["dc"];
            var sdt = jsonCart["sdt"];
            var mota = jsonCart["mota"];
            var gt = jsonCart["gt"];
            var ten = jsonCart["ten"];
            var nguoitao = Session["maad"].ToString();

            CHINHANH Sp = new CHINHANH();
            var them = Sp.update(MA, ten, dc, sdt, mota, gt, nguoitao);
            if (them == 1)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Đã xảy ra lỗi"
                });
            }
        }
        public JsonResult CNSPCHINHANH(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            SPCHINHANH sp = new SPCHINHANH();
            var listThem = jsonCart[0]["listThem"];
            var listBo = jsonCart[0]["listBo"];
            var listCo = jsonCart[0]["listCo"];
            var id = jsonCart[0]["id"];
            var nguoitao = Session["maad"].ToString();
            foreach (var item in listThem)
            {
                sp.them(item, id, nguoitao);
            }
            foreach (var item in listBo)
            {
                sp.update(item, id, nguoitao);
            }
            foreach (var item in listCo)
            {
                sp.update2(item, id, nguoitao);
            }
            return Json(new
            {
                status = true,
            });
        }
        public JsonResult THEMNV(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var dc = jsonCart["dc"];
            var sdt = jsonCart["sdt"];
            var email = jsonCart["email"];
            var cn = jsonCart["cn"];
            var mk = jsonCart["mk"];
            var ten = jsonCart["ten"];
            var quyen = jsonCart["quyen"];
            var nguoitao = Session["maad"].ToString();

            NHANVIEN Sp = new NHANVIEN();
            var ktraMa = Sp.them(MA, ten, sdt, dc, mk, cn, email, nguoitao,quyen);
            if (ktraMa == -1)
            {
                return Json(new
                {
                    status = false,
                    erro = "Tên đăng nhập đã tồn tại"
                });
            }
            else
            {
                if (ktraMa == 0)
                {
                    return Json(new
                {
                    status = false,
                    erro = "Đã xảy ra lỗi"
                });
                }
                else
                {
                    return Json(new
                    {
                        status = true,
                    });
                }
            }

        }
        public JsonResult ChiTietNV(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            string MA = jsonCart["id"];

            NHANVIEN Sp = new NHANVIEN();
            var mh = Sp.getData(MA);
            return Json(new
            {
                status = true,
                data = mh,
            });
        }
        public JsonResult UPDATENV(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var dc = jsonCart["dc"];
            var sdt = jsonCart["sdt"];
            var email = jsonCart["email"];
            var cn = jsonCart["cn"];
            var mk = jsonCart["mk"];
            var ten = jsonCart["ten"];
            var quyen = jsonCart["quyen"];
            var nguoitao = Session["maad"].ToString();

            NHANVIEN Sp = new NHANVIEN();
            var them = Sp.update(MA, ten, sdt, dc, mk, cn, email, nguoitao,quyen);
            if (them == 1)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Đã xảy ra lỗi"
                });
            }
        }
        public JsonResult THEMNCCNHAP(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var dc = jsonCart["dc"];
            var sdt = jsonCart["sdt"];
            var mota = jsonCart["mota"];
            var gt = jsonCart["gt"];
            var ten = jsonCart["ten"];
            var kyhieuhd = jsonCart["kyhieuhd"];
            var kyhieumauhd = jsonCart["kyhieumauhd"];
            var nguoitao = Session["maad"].ToString();

            NHACCNHAP Sp = new NHACCNHAP();
            var ktraMa = Sp.ktra2(MA);
            if (ktraMa == 0)
            {
                var them = Sp.them(MA, ten, dc, sdt, mota, gt, nguoitao, kyhieuhd, kyhieumauhd);
                if (them == 1)
                {
                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        erro = "Đã xảy ra lỗi"
                    });
                }
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Mã TG đã tồn tại"
                });
            }
        }
        public JsonResult ChiTietNCCNHAP(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            string MA = jsonCart["id"];

            NHACCNHAP Sp = new NHACCNHAP();
            var mh = Sp.getData3(MA);
            return Json(new
            {
                status = true,
                data = mh,
            });
        }
        public JsonResult UPDATENCCNHAP(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var MA = jsonCart["MA"];
            var dc = jsonCart["dc"];
            var sdt = jsonCart["sdt"];
            var mota = jsonCart["mota"];
            var gt = jsonCart["gt"];
            var ten = jsonCart["ten"];
            var kyhieuhd = jsonCart["kyhieuhd"];
            var kyhieumauhd = jsonCart["kyhieumauhd"];
            var nguoitao = Session["maad"].ToString();

            NHACCNHAP Sp = new NHACCNHAP();
            var them = Sp.update(MA, ten, dc, sdt, mota, gt, nguoitao, kyhieuhd, kyhieumauhd);
            if (them == 1)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    erro = "Đã xảy ra lỗi"
                });
            }
        }
        public JsonResult SPCN(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var ten = jsonCart["q"];
            var cn = jsonCart["cn"];
            SPCHINHANH Sp = new SPCHINHANH();
            var mh = Sp.getData2(ten, cn);
            return Json(new
            {
                status = true,
                data = mh,
            });
        }
        public JsonResult THEMPHIEU(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var ncc = jsonCart["ncc"];
            var shd = jsonCart["shd"];
            var kyhieu = jsonCart["kyhieu"];
            var mauhd = jsonCart["mauhd"];
            var ngaynhap = jsonCart["ngaynhap"];
            var ngayhd = jsonCart["ngayhd"];
            var ngaynhan = jsonCart["ngaynhan"];
            var cn = jsonCart["cn"];
            var tong = jsonCart["tong"];
            var tienvat = jsonCart["tienvat"];
            var thanhtienvat = jsonCart["thanhtienvat"];
            var ghichu = jsonCart["ghichu"];
            var vat = jsonCart["vat"];
            var nguoitao = Session["maad"].ToString();
            PHIEUNHAP PN = new PHIEUNHAP();
            PN.them(shd, kyhieu, mauhd, ngaynhap, ngayhd, ngaynhan, cn, tong, vat, tienvat, thanhtienvat, ghichu, nguoitao, ncc);
            return Json(new
            {
                status = true,
                ID = PN.LayId()
            });
        }
        public JsonResult THEMPHIEUCT(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var maphieu = jsonCart["maphieu"];
            var masp = jsonCart["masp"];
            var SL = jsonCart["SL"];
            var TT = jsonCart["TT"];
            var DGVAT = jsonCart["DGVAT"];
            var DG= jsonCart["DG"];
            var TTVAT = jsonCart["TTVAT"];
            PHIEUNHAP PN = new PHIEUNHAP();
            PN.themCT(maphieu, masp, DG, DGVAT, TT, TTVAT, SL);
            return Json(new
            {
                status = true,
            });
        }
        public JsonResult SUAPHIEU(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var ma = jsonCart["ma"];
            var ncc = jsonCart["ncc"];
            var shd = jsonCart["shd"];
            var kyhieu = jsonCart["kyhieu"];
            var mauhd = jsonCart["mauhd"];
            var ngaynhap = jsonCart["ngaynhap"];
            var ngayhd = jsonCart["ngayhd"];
            var ngaynhan = jsonCart["ngaynhan"];
            var cn = jsonCart["cn"];
            var tong = jsonCart["tong"];
            var tienvat = jsonCart["tienvat"];
            var thanhtienvat = jsonCart["thanhtienvat"];
            var ghichu = jsonCart["ghichu"];
            var vat = jsonCart["vat"];
            var nguoitao = Session["maad"].ToString();
            PHIEUNHAP PN = new PHIEUNHAP();
            PN.update(ma,shd, kyhieu, mauhd, ngaynhap, ngayhd, ngaynhan, cn, tong, vat, tienvat, thanhtienvat, ghichu, nguoitao, ncc);
            PN.updateAll(ma);
            return Json(new
            {
                status = true,
            });
        }
        public JsonResult UPDATECTPHIEU(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var maphieu = jsonCart["maphieu"];
            var masp = jsonCart["masp"];
            var SL = jsonCart["SL"];
            var TT = jsonCart["TT"];
            var DGVAT = jsonCart["DGVAT"];
            var DG = jsonCart["DG"];
            var TTVAT = jsonCart["TTVAT"];
            PHIEUNHAP PN = new PHIEUNHAP();
            var kq = PN.KtraSpPhieu(maphieu, masp);
            if (kq == 0)
            {
                PN.themCT(maphieu, masp, DG, DGVAT, TT, TTVAT, SL);
            }
            else
            {
                PN.updateCTPhieus(maphieu, masp, DG, DGVAT, TT, TTVAT, SL);
            }
            
            return Json(new
            {
                status = true,
            });
        }
        public JsonResult THEMQUYEN(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var ma = jsonCart["ma"];
            var ten = jsonCart["ten"];
            QUYEN quyen = new QUYEN();
            quyen.them(ma, ten);
            return Json(new
            {
                status = true,
            });
        }
        public JsonResult ChiTietQuyen(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            string MA = jsonCart["id"];

            QUYEN quyen = new QUYEN();
            var mh = quyen.getData(MA);
            return Json(new
            {
                status = true,
                data = mh,
            });
        }
        public JsonResult CNQUYEN(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var ma = jsonCart["ma"];
            var ten = jsonCart["ten"];
            QUYEN quyen = new QUYEN();
            quyen.update(ma, ten);
            return Json(new
            {
                status = true,
            });
        }
        public JsonResult THEMLoaiQUYEN(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var ma = jsonCart["ma"];
            var ten = jsonCart["ten"];
            LOAIQUYEN quyen = new LOAIQUYEN();
            quyen.them(ma, ten);
            return Json(new
            {
                status = true,
            });
        }
        public JsonResult ChiTietLoaiQuyen(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            string MA = jsonCart["id"];

            LOAIQUYEN quyen = new LOAIQUYEN();
            var mh = quyen.getData(MA);
            return Json(new
            {
                status = true,
                data = mh,
            });
        }
        public JsonResult CNLoaiQUYEN(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            var ma = jsonCart["ma"];
            var ten = jsonCart["ten"];
            LOAIQUYEN quyen = new LOAIQUYEN();
            quyen.update(ma, ten);
            return Json(new
            {
                status = true,
            });
        }
        public JsonResult CNLOAIQUYENOFQUYEN(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            LOAIQUYENOFQUYEN sp = new LOAIQUYENOFQUYEN();
            var listThem = jsonCart[0]["listThem"];
            var listBo = jsonCart[0]["listBo"];
            var listCo = jsonCart[0]["listCo"];
            var id = jsonCart[0]["id"];
            foreach (var item in listThem)
            {
                sp.them(item, id);
            }
            foreach (var item in listBo)
            {
                sp.update(item, id);
            }
            foreach (var item in listCo)
            {
                sp.update2(item, id);
            }
            return Json(new
            {
                status = true,
            });
        }
        public JsonResult CNLOAIQUYENOFNV(string cartModel)
        {
            //tạo 1 đối tượng dạng json
            var jsonCart = new JavaScriptSerializer().Deserialize<dynamic>(cartModel);
            LOAIQUYENOFNHANVIEN sp = new LOAIQUYENOFNHANVIEN();
            var listThem = jsonCart[0]["listThem"];
            var listBo = jsonCart[0]["listBo"];
            var id = jsonCart[0]["id"];
            var listCo = jsonCart[0]["listCo"];
            foreach (var item in listCo)
            {
                sp.update2(item, id);
            }
            foreach (var item in listThem)
            {
                sp.them(item, id);
            }
            foreach (var item in listBo)
            {
                sp.update(item, id);
            }
            return Json(new
            {
                status = true,
            });
        }
    }
}
