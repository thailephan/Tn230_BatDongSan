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

        // GET: Admin/QuanHuyens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QuanHuyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaQuanHuyen,TenQuanHuyen")] QuanHuyen quanHuyen)
        {
            if (ModelState.IsValid)
            {
                db.QuanHuyens.Add(quanHuyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quanHuyen);
        }

        // GET: Admin/QuanHuyens/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Admin/QuanHuyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaQuanHuyen,TenQuanHuyen")] QuanHuyen quanHuyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quanHuyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quanHuyen);
        }

        // GET: Admin/QuanHuyens/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Admin/QuanHuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuanHuyen quanHuyen = db.QuanHuyens.Find(id);
            db.QuanHuyens.Remove(quanHuyen);
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
