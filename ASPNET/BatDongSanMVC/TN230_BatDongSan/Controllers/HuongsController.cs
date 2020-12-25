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
    public class HuongsController : Controller
    {
        private DbContextWeb db = new DbContextWeb();

        // GET: Admin/Huongs
        public ActionResult Index()
        {
            return View(db.Huongs.ToList());
        }

        // GET: Admin/Huongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Huong huong = db.Huongs.Find(id);
            if (huong == null)
            {
                return HttpNotFound();
            }
            return View(huong);
        }
    }
}
