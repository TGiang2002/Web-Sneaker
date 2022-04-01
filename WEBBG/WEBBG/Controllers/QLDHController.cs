using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBBG.Models;

namespace WEBBG.Controllers
{
    public class QLDHController : Controller
    {
        // GET: QLDH
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View(db.DONDATHANGs.ToList());
        }

        public ActionResult Details(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var dh = from donhang in db.DONDATHANGs where donhang.MADH == id select donhang;
                return View(dh.SingleOrDefault());
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
        public ActionResult Create(DONDATHANG dh)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                db.DONDATHANGs.InsertOnSubmit(dh);
                db.SubmitChanges();
                return RedirectToAction("Index", "QLDH");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else

            {
                var dh = from donhang in db.DONDATHANGs where donhang.MADH == id select donhang;
                return View(dh.SingleOrDefault());
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Xacnhanxoa(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
               DONDATHANG dh = db.DONDATHANGs.SingleOrDefault(n => n.MADH == id);
                db.DONDATHANGs.DeleteOnSubmit(dh);
                db.SubmitChanges();
                return RedirectToAction("Index", "QLDH");
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var dh = from donhang in db.DONDATHANGs where donhang.MADH == id select donhang;
                return View(dh.SingleOrDefault());
            }
        }

        [HttpPost, ActionName("Sua")]

        //
        public ActionResult Update(int id)
        {
            DONDATHANG dh = db.DONDATHANGs.Where(n => n.MADH== id).SingleOrDefault();
            UpdateModel(dh);
            db.SubmitChanges();
            return RedirectToAction("Index", "QLDH");

        }

    }
}
    
    
   