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
    public class ThongTinBDSController : Controller
    {
        private DbContextWeb db = new DbContextWeb();

        // GET: Admin/ThongTinBDS
        public ActionResult Index()
        {
            var thongTinBDS = db.ThongTinBDS.Include(t => t.Anh).Include(t => t.Huong).Include(t => t.KhuDanCu).Include(t => t.LoaiBD).Include(t => t.QuanHuyen).Include(t => t.ThongTin);
            return View(thongTinBDS.ToList());
        }

        // GET: Admin/ThongTinBDS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinBDS thongTinBDS = db.ThongTinBDS.Find(id);
            if (thongTinBDS == null)
            {
                return HttpNotFound();
            }
            return View(thongTinBDS);
        }
    }
}
