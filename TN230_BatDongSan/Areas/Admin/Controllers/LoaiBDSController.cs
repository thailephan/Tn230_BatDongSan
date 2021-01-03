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
    public class LoaiBDSController : Controller
    {
        private DbContextWeb db = new DbContextWeb();

        // GET: Admin/LoaiBDS
        public ActionResult Index()
        {
            return View(db.LoaiBDS.ToList());
        }

        // GET: Admin/LoaiBDS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiBDS loaiBDS = db.LoaiBDS.Find(id);
            if (loaiBDS == null)
            {
                return HttpNotFound();
            }
            return View(loaiBDS);
        }

        // GET: Admin/LoaiBDS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiBDS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoai")] LoaiBDS loaiBDS)
        {
            if (ModelState.IsValid)
            {
                db.LoaiBDS.Add(loaiBDS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiBDS);
        }

        // GET: Admin/LoaiBDS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiBDS loaiBDS = db.LoaiBDS.Find(id);
            if (loaiBDS == null)
            {
                return HttpNotFound();
            }
            return View(loaiBDS);
        }

        // POST: Admin/LoaiBDS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoai")] LoaiBDS loaiBDS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiBDS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiBDS);
        }

        // GET: Admin/LoaiBDS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiBDS loaiBDS = db.LoaiBDS.Find(id);
            if (loaiBDS == null)
            {
                return HttpNotFound();
            }
            return View(loaiBDS);
        }

        // POST: Admin/LoaiBDS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiBDS loaiBDS = db.LoaiBDS.Find(id);
            db.LoaiBDS.Remove(loaiBDS);
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
