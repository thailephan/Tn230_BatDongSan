﻿using System;
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
    [Authorize]
    public class ThongTinsController : Controller
    {
        private DbContextWeb db = new DbContextWeb();

        // GET: Admin/ThongTins
        public ActionResult Index()
        {
            var thongTins = db.ThongTinsBDS.Include(t => t.TaiKhoan);
            return View(thongTins.ToList());
        }

        // GET: Admin/ThongTins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTin thongTin = db.ThongTinsBDS.Find(id);
            if (thongTin == null)
            {
                return HttpNotFound();
            }
            return View(thongTin);
        }

        // GET: Admin/ThongTins/Create
        public ActionResult Create()
        {
            ViewBag.UserName = new SelectList(db.TaiKhoans, "UserName", "Password");
            return View();
        }

        // POST: Admin/ThongTins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaUser,HoTen,DiaChi,SDT,NamSinh,GioiTinh,UserName")] ThongTin thongTin)
        {
            if (ModelState.IsValid)
            {
                db.ThongTinsBDS.Add(thongTin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserName = new SelectList(db.TaiKhoans, "UserName", "Password", thongTin.UserName);
            return View(thongTin);
        }

        // GET: Admin/ThongTins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTin thongTin = db.ThongTinsBDS.Find(id);
            if (thongTin == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserName = new SelectList(db.TaiKhoans, "UserName", "Password", thongTin.UserName);
            return View(thongTin);
        }

        // POST: Admin/ThongTins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaUser,HoTen,DiaChi,SDT,NamSinh,GioiTinh,UserName")] ThongTin thongTin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongTin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserName = new SelectList(db.TaiKhoans, "UserName", "Password", thongTin.UserName);
            return View(thongTin);
        }

        // GET: Admin/ThongTins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTin thongTin = db.ThongTinsBDS.Find(id);
            if (thongTin == null)
            {
                return HttpNotFound();
            }
            return View(thongTin);
        }

        // POST: Admin/ThongTins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongTin thongTin = db.ThongTinsBDS.Find(id);
            db.ThongTinsBDS.Remove(thongTin);
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
