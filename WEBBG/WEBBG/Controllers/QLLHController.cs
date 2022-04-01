using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBBG.Models;

namespace WEBBG.Controllers
{
    public class QLLHController : Controller
    {
        // GET: QLLH
        
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View(db.LIENHEs.ToList());
        }

        public ActionResult Details(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var lh = from lienhe in db.LIENHEs where lienhe.MALIENHE == id select lienhe;
                return View(lh.SingleOrDefault());
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
        public ActionResult Create(LIENHE lh)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                db.LIENHEs.InsertOnSubmit(lh);
                db.SubmitChanges();
                return RedirectToAction("Index", "QLLH");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else

            {
                var lienhe = from lh in db.LIENHEs where lh.MALIENHE == id select lh;
                return View(lienhe.SingleOrDefault());
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Xacnhanxoa(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                LIENHE lienhe = db.LIENHEs.SingleOrDefault(n => n.MALIENHE == id);
                db.LIENHEs.DeleteOnSubmit(lienhe);
                db.SubmitChanges();
                return RedirectToAction("Index", "QLLH");
            }
        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    if (Session["Taikhoanadmin"] == null)
        //        return RedirectToAction("Login", "Admin");
        //    else
        //    {
        //        var lienhe = from lh in db.LIENHEs where lh.MALIENHE == id select lh;
        //        return View(lienhe.SingleOrDefault());
        //    }
        //}

        //[HttpPost, ActionName("Edit")]

        //public ActionResult Capnhat(int id)
        //{
        //    LIENHE lienhe = db.LIENHEs.Where(n => n.MALIENHE == id).SingleOrDefault();
        //    UpdateModel(lienhe);
        //    db.SubmitChanges();
        //    return RedirectToAction("Index", "QLLH");

        //}

    }
}
    
    