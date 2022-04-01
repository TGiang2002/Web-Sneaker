using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WEBBG.Models;

namespace WEBBG.Controllers
{
    public class KhachHangController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        // GET: KhachHang
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection collection, KHACHHANG kh)
        {
            var hoten = collection["HotenKH"];
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            var nhaplaimatkhau = collection["nhaplaimatkhau"];
            var diachi = collection["Diachi"];
            var email = collection["Email"];
            var dienthoai = collection["dienthoai"];
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên không được để trống";
            }
            else if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Họ tên không được để trống";
            }

            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(nhaplaimatkhau))
            {
                ViewData["Loi4"] = "Nhập mật khẩu lại";
            }
            else if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = "Nhập Email";
            }
            else if (String.IsNullOrEmpty(diachi))
            {
                ViewData["Loi6"] = "Nhập Địa chỉ";
            }

            else if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi7"] = "Nhập SĐT";
            }
            else
            {
                kh.HOTEN = hoten;
                kh.MATKHAU = matkhau;
                kh.EMAIL = email;
                kh.DIACHI = diachi;
                kh.TAIKHOAN = tendn;
                kh.DIENTHOAIKH = dienthoai;
                db.KHACHHANGs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("Login");

            }
            return this.Register();

        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Nhập mật khẩu";
            }
            else
            {
                KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.TAIKHOAN == tendn && n.MATKHAU == matkhau);

                if (kh != null)
                {
                    //ViewBag.Thongbao = "ĐĂNG NHẬP THÀNH CÔNG";
                    Session["TAIKHOAN"] = kh;

                    return RedirectToAction("Index", "Site");


                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }


    }
}