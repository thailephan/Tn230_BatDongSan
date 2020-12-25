using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DbContextModel.Framework;

namespace TN230_BatDongSan.Controllers
{
    public class LoaiBDSController : Controller
    {
        private DbContextWeb db = new DbContextWeb();

        // GET: Admin/LoaiBDS
        public ActionResult Index()
        {
            return View(db.LoaiBDS.ToList());
        }

        // GET: Admin/LoaiBDS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiBDS loaiBDS = db.LoaiBDS.Find(id);
            if (loaiBDS == null)
            {
                return HttpNotFound();
            }
            return View(loaiBDS);
        }
    }
}
