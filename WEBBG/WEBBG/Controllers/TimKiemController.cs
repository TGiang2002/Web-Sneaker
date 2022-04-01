using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBBG.Models;

namespace WEBBG.Controllers
{
    public class TimKiemController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        // GET: TimKiem
        public ActionResult KQTimKiem( string search)
        {
            var lstsp = db.SANPHAMs.Where(n => n.TENSP.Contains(search));
            return View(lstsp.OrderBy(n=>n.TENSP));
        }
    }
}