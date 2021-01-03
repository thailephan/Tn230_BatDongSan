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

        // GET: Admin/KhuDanCus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KhuDanCus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhuDanCu,TenKhuDanCu")] KhuDanCu khuDanCu)
        {
            if (ModelState.IsValid)
            {
                db.KhuDanCus.Add(khuDanCu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khuDanCu);
        }

        // GET: Admin/KhuDanCus/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Admin/KhuDanCus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhuDanCu,TenKhuDanCu")] KhuDanCu khuDanCu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khuDanCu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khuDanCu);
        }

        // GET: Admin/KhuDanCus/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Admin/KhuDanCus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhuDanCu khuDanCu = db.KhuDanCus.Find(id);
            db.KhuDanCus.Remove(khuDanCu);
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
