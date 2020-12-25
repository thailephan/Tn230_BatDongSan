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
    public class QuanHuyensController : Controller
    {
        private DbContextWeb db = new DbContextWeb();

        // GET: Admin/QuanHuyens
        public ActionResult Index()
        {
            return View(db.QuanHuyens.ToList());
        }

        // GET: Admin/QuanHuyens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanHuyen quanHuyen = db.QuanHuyens.Find(id);
            if (quanHuyen == null)
            {
                return HttpNotFound();
            }
            return View(quanHuyen);
        }
    }
}
