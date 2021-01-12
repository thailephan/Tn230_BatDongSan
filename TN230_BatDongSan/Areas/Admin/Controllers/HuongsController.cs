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
    [Authorize]
    public class HuongsController : Controller
    {
        private DbContextWeb db = new DbContextWeb();

        // GET: Admin/Huongs
        public ActionResult Index()
        {
            return View(db.Huongs.ToList());
        }

        
        // GET: Admin/Huongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Huongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHuong,TenHuong")] Huong huong)
        {
            if (ModelState.IsValid)
            {
                db.Huongs.Add(huong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(huong);
        }

        // GET: Admin/Huongs/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Admin/Huongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHuong,TenHuong")] Huong huong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(huong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(huong);
        }

        // GET: Admin/Huongs/Delete/5
        public ActionResult Delete(int? id)
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
            db.Huongs.Remove(huong);
            db.SaveChanges();
            return View("Index", db.Huongs.Select( h => h));
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
