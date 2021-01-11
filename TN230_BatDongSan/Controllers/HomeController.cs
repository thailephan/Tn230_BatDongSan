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
            ViewBag.ListQuanHuyen = new SelectList(db.QuanHuyens, "MaQuanHuyen", "TenQuanHuyen");

            return View();
        }

        public ActionResult showInfo(int id_mahuong, int id_khudancu, int id_maloaibds, int id_maquanhuyen, int id_giatien)
        {
            var dsbds = db.ThongTinBDS.ToList();
            if (id_mahuong > -1) dsbds = dsbds.FindAll(n => n.MaHuong == id_mahuong);
            if (id_khudancu > -1) dsbds = dsbds.FindAll(n => n.MaKhuDanCu == id_khudancu);
            if(id_maloaibds > -1) dsbds = dsbds.FindAll(n => n.MaLoai == id_maloaibds);
            if (id_maquanhuyen > -1) dsbds = dsbds.FindAll(n => n.MaQuanHuyen == id_maquanhuyen);
            switch (id_giatien)
            {
                case 0:
                    dsbds = dsbds.FindAll(n => (n.Gia >= 0 && n.Gia < 500000000)); break;
                case 1:
                    dsbds = dsbds.FindAll(n => (n.Gia >= 500000000 && n.Gia < 1000000000)); break;
                case 2:
                    dsbds = dsbds.FindAll(n => (n.Gia >= 1000000000 && n.Gia < 2000000000)); break;
                case 3:
                    dsbds = dsbds.FindAll(n => (n.Gia >= 2000000000 && n.Gia < 3000000000)); break;
                case 4:
                    dsbds = dsbds.FindAll(n => (n.Gia >= 3000000000 && n.Gia < 4000000000)); break;
                case 5:
                    dsbds = dsbds.FindAll(n => n.Gia >= 4000000000); break;

            }
            return PartialView(dsbds);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ViewSearch(int MaHuong = -1, int MaKhuDanCu = -1, int MaLoai = -1, int MaQuanHuyen = -1, int GiaTien = -1)
        {
            ViewBag.GGG = MaHuong;
            var dsbds = db.ThongTinBDS.ToList();
            if (MaHuong > -1) dsbds = dsbds.FindAll(n => n.MaHuong == MaHuong);
            if (MaKhuDanCu > -1) dsbds = dsbds.FindAll(n => n.MaKhuDanCu == MaKhuDanCu);
            if (MaLoai > -1) dsbds = dsbds.FindAll(n => n.MaLoai == MaLoai);
            if (MaQuanHuyen > -1) dsbds = dsbds.FindAll(n => n.MaQuanHuyen == MaQuanHuyen);
            switch (GiaTien)
            {
                case 0:
                    dsbds = dsbds.FindAll(n => (n.Gia >= 0 && n.Gia < 500000000)); break;
                case 1:
                    dsbds = dsbds.FindAll(n => (n.Gia >= 500000000 && n.Gia < 1000000000)); break;
                case 2:
                    dsbds = dsbds.FindAll(n => (n.Gia >= 1000000000 && n.Gia < 2000000000)); break;
                case 3:
                    dsbds = dsbds.FindAll(n => (n.Gia >= 2000000000 && n.Gia < 3000000000)); break;
                case 4:
                    dsbds = dsbds.FindAll(n => (n.Gia >= 3000000000 && n.Gia < 4000000000)); break;
                case 5:
                    dsbds = dsbds.FindAll(n => n.Gia >= 4000000000); break;

            }
            return View(dsbds);
        }
    }
}