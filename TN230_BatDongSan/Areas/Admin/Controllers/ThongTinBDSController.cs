using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DbContextModel.Framework;

namespace TN230_BatDongSan.Areas.Admin.Controllers
{
    public class ThongTinBDSController : Controller
    {
        private DbContextWeb db = new DbContextWeb();

        // GET: Admin/ThongTinBDS
        public ActionResult Index()
        {
            var thongTinBDS = db.ThongTinBDS.Include(t => t.Huong).Include(t => t.KhuDanCu).Include(t => t.LoaiBD).Include(t => t.QuanHuyen).Include(t => t.ThongTin);
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

        // GET: Admin/ThongTinBDS/Create
        public ActionResult Create()
        {
            ViewBag.MaHuong = new SelectList(db.Huongs, "MaHuong", "TenHuong");
            ViewBag.MaKhuDanCu = new SelectList(db.KhuDanCus, "MaKhuDanCu", "TenKhuDanCu");
            ViewBag.MaLoai = new SelectList(db.LoaiBDS, "MaLoai", "TenLoai");
            ViewBag.MaQuanHuyen = new SelectList(db.QuanHuyens, "MaQuanHuyen", "TenQuanHuyen");
            ViewBag.MaUser = new SelectList(db.ThongTins, "MaUser", "HoTen");
            return View();
        }

        // POST: Admin/ThongTinBDS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTin,TieuDe,NgayTao,ChieuDai,ChieuRong,MoTa,SDTChuBan,Gia,MaHuong,MaUser,MaLoai,MaQuanHuyen,MaKhuDanCu")] ThongTinBDS thongTinBDS)
        {
            if (ModelState.IsValid)
            {
                db.ThongTinBDS.Add(thongTinBDS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHuong = new SelectList(db.Huongs, "MaHuong", "TenHuong", thongTinBDS.MaHuong);
            ViewBag.MaKhuDanCu = new SelectList(db.KhuDanCus, "MaKhuDanCu", "TenKhuDanCu", thongTinBDS.MaKhuDanCu);
            ViewBag.MaLoai = new SelectList(db.LoaiBDS, "MaLoai", "TenLoai", thongTinBDS.MaLoai);
            ViewBag.MaQuanHuyen = new SelectList(db.QuanHuyens, "MaQuanHuyen", "TenQuanHuyen", thongTinBDS.MaQuanHuyen);
            ViewBag.MaUser = new SelectList(db.ThongTins, "MaUser", "HoTen", thongTinBDS.MaUser);
            return View(thongTinBDS);
        }

        // GET: Admin/ThongTinBDS/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.MaHuong = new SelectList(db.Huongs, "MaHuong", "TenHuong", thongTinBDS.MaHuong);
            ViewBag.MaKhuDanCu = new SelectList(db.KhuDanCus, "MaKhuDanCu", "TenKhuDanCu", thongTinBDS.MaKhuDanCu);
            ViewBag.MaLoai = new SelectList(db.LoaiBDS, "MaLoai", "TenLoai", thongTinBDS.MaLoai);
            ViewBag.MaQuanHuyen = new SelectList(db.QuanHuyens, "MaQuanHuyen", "TenQuanHuyen", thongTinBDS.MaQuanHuyen);
            ViewBag.MaUser = new SelectList(db.ThongTins, "MaUser", "HoTen", thongTinBDS.MaUser);
            return View(thongTinBDS);
        }

        // POST: Admin/ThongTinBDS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTin,TieuDe,NgayTao,ChieuDai,ChieuRong,MoTa,SDTChuBan,Gia,MaHuong,MaUser,MaLoai,MaQuanHuyen,MaKhuDanCu")] ThongTinBDS thongTinBDS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongTinBDS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHuong = new SelectList(db.Huongs, "MaHuong", "TenHuong", thongTinBDS.MaHuong);
            ViewBag.MaKhuDanCu = new SelectList(db.KhuDanCus, "MaKhuDanCu", "TenKhuDanCu", thongTinBDS.MaKhuDanCu);
            ViewBag.MaLoai = new SelectList(db.LoaiBDS, "MaLoai", "TenLoai", thongTinBDS.MaLoai);
            ViewBag.MaQuanHuyen = new SelectList(db.QuanHuyens, "MaQuanHuyen", "TenQuanHuyen", thongTinBDS.MaQuanHuyen);
            ViewBag.MaUser = new SelectList(db.ThongTins, "MaUser", "HoTen", thongTinBDS.MaUser);
            return View(thongTinBDS);
        }

        // GET: Admin/ThongTinBDS/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Admin/ThongTinBDS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongTinBDS thongTinBDS = db.ThongTinBDS.Find(id);
            db.ThongTinBDS.Remove(thongTinBDS);
            db.SaveChanges();
            return RedirectToAction("Index");
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
