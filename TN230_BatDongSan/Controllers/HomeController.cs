using DbContextModel.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TN230_BatDongSan.Controllers
{
    public class HomeController : Controller
    {
        DbContextWeb db = new DbContextWeb();
        
        public ActionResult Index()
        {
            
            ViewBag.ListHuong = new SelectList(db.Huongs, "MaHuong", "TenHuong");
            ViewBag.ListKhudancu = new SelectList(db.KhuDanCus, "MaKhuDanCu", "TenKhuDanCu");
            ViewBag.ListLoaiBDS = new SelectList(db.LoaiBDS, "MaLoai", "TenLoai");
            return View();
        }

        public ActionResult showInfo(int id)
        {
            var phhuong = db.ThongTinBDS.Where(n => n.MaHuong == id);
            var khudancu = db.ThongTinBDS.Where(n => n.MaKhuDanCu == id);
            var loai = db.ThongTinBDS.Where(n => n.MaLoai == id);

            return PartialView(phhuong.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}