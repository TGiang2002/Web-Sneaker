﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBBG.Models;

namespace WEBBG.Controllers
{
    public class NhaCCController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        // GET: NhaCC
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            return View(db.NCCs.ToList());
        }

        public ActionResult Details(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            { var nhacungcap = from ncc in db.NCCs where ncc.MANCC == id select ncc;
                return View(nhacungcap.SingleOrDefault());
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View();
          
        }

        [HttpPost]
        public ActionResult Create(NCC nhacungcap)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                db.NCCs.InsertOnSubmit(nhacungcap);
                db.SubmitChanges();
                return RedirectToAction("Index", "NhaCC");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else

            {
                var nhacungcap = from ncc in db.NCCs where ncc.MANCC == id select ncc;
                return View(nhacungcap.SingleOrDefault());
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Xacnhanxoa(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                NCC nhacungcap = db.NCCs.SingleOrDefault(n => n.MANCC == id);
                db.NCCs.DeleteOnSubmit(nhacungcap);
                db.SubmitChanges();
                return RedirectToAction("Index", "NhaCC");
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var ncc = from nhacc in db.NCCs where nhacc.MANCC == id select nhacc;
                return View(ncc.SingleOrDefault());
            }
        }

        [HttpPost, ActionName("Edit")]

        public ActionResult Capnhat(int id)
        {
            NCC ncc = db.NCCs.Where(n => n.MANCC== id).SingleOrDefault();
            UpdateModel(ncc);
            db.SubmitChanges();
            return RedirectToAction("Index", "NhaCC");

        }


    }
}