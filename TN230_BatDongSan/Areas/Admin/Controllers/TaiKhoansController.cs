using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DbContextModel.Framework;

namespace TN230_BatDongSan.Areas.Admin.Controllers
{
    [Authorize]
    public class TaiKhoansController : Controller
    {
        private DbContextWeb db = new DbContextWeb();

        // GET: Admin/TaiKhoans
        public ActionResult Index()
        {
            return View(db.TaiKhoans.Include(tk => tk.ThongTins));
        }

        // GET: Admin/TaiKhoans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            taiKhoan.ThongTins = db.ThongTins.Where(tt => tt.UserName.Equals(id)).ToList();
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "UserName,Password")] TaiKhoan taiKhoan, 
            [Bind(Include = "MaUser,HoTen,DiaChi,SDT,NamSinh,GioiTinh,UserName")] ThongTin thongTin
            )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.TaiKhoans.Add(taiKhoan);
                    db.ThongTins.Add(thongTin);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("Save To DB", "Máy chủ gặp sự cố khi sao thêm, vui lòng kiểm tra lại thông tin đã nhập");
                    return View();
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            taiKhoan.ThongTins = db.ThongTins.Where(tt => tt.UserName.Equals(id)).ToList();
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "UserName,Password")] TaiKhoan taiKhoan,
            [Bind(Include = "MaUser,HoTen,DiaChi,SDT,NamSinh,GioiTinh,UserName")] ThongTin thongTin
            )
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.Entry(thongTin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            taiKhoan.ThongTins = db.ThongTins.Where(tt => tt.UserName.Equals(id)).ToList();
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            ThongTin thongTin = db.ThongTins.Where(tt => tt.UserName.Equals(id)).FirstOrDefault();
            db.ThongTins.Remove(thongTin);
            db.TaiKhoans.Remove(taiKhoan);
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
