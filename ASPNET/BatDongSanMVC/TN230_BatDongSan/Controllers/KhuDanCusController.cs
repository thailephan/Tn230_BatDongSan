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
    public class KhuDanCusController : Controller
    {
        private DbContextWeb db = new DbContextWeb();

        // GET: Admin/KhuDanCus
        public ActionResult Index()
        {
            return View(db.KhuDanCus.ToList());
        }

        // GET: Admin/KhuDanCus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhuDanCu khuDanCu = db.KhuDanCus.Find(id);
            if (khuDanCu == null)
            {
                return HttpNotFound();
            }
            return View(khuDanCu);
        }
    }
}
