using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DbContextModel;
using DbContextModel.Framework;
using Microsoft.AspNet.Identity;
using TN230_BatDongSan.Areas.Admin.Code.Constant;

namespace TN230_BatDongSan.Areas.Admin.Controllers
{
    [Authorize]
    public class ThongTinBDSController : Controller
    {
        private DbContextWeb db = new DbContextWeb();

        // GET: Admin/ThongTinBDS
        public ActionResult Index(int page = 1, int pageSize = 2)
        {
            PageListShared listPage = PageListShared.getInstance();
            var model = listPage.ListAllPageThongTinBDS(page, pageSize);
            return View(model);
        }

        // GET: Admin/ThongTinBDS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinBDS thongTinBDS = db.ThongTinBDS.Find(id);
            thongTinBDS.Anhs = db.Anhs.Where(a => a.MaTin == thongTinBDS.MaTin).ToList();

            if (thongTinBDS == null)
            {
                return HttpNotFound();
            }
            return View(thongTinBDS);
        }

        // GET: Admin/ThongTinBDS/Create
        public ActionResult Create()
        {
            string username = @User.Identity.GetUserName();
            ThongTinBDS thongTinBDS = new ThongTinBDS
            {
                NgayTao = DateTime.Now,
                MaUser = db.ThongTins.Where(tt => tt.UserName.Equals(username)).FirstOrDefault().MaUser
            };
            ViewBag.UserName = username;
            ViewBag.MaHuong = new SelectList(db.Huongs, "MaHuong", "TenHuong");
            ViewBag.MaKhuDanCu = new SelectList(db.KhuDanCus, "MaKhuDanCu", "TenKhuDanCu");
            ViewBag.MaLoai = new SelectList(db.LoaiBDS, "MaLoai", "TenLoai");
            ViewBag.MaQuanHuyen = new SelectList(db.QuanHuyens, "MaQuanHuyen", "TenQuanHuyen");
            /*ViewBag.MaUser = new SelectList(db.ThongTins, "MaUser", "HoTen");*/
            return View(thongTinBDS);
        }

        // POST: Admin/ThongTinBDS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "MaTin,TieuDe,NgayTao,ChieuDai,ChieuRong,MoTa,SDTChuBan,Gia,MaHuong,MaUser,MaLoai,MaQuanHuyen,MaKhuDanCu")] ThongTinBDS thongTinBDS,
            HttpPostedFileBase[] files
            )
        {
            if (ModelState.IsValid)
            {
                thongTinBDS.NgayTao = DateTime.Now;
                try
                {
                    ICollection<Anh> linkAnhs = new List<Anh>();

                    foreach (HttpPostedFileBase file in files)
                    {
                        //Checking file is available to save.  
                        if (file != null)
                        {
                            var InputFileName = Guid.NewGuid().ToString().Replace("\\", "") + DateTime.Now.ToString("dd_mm_yyyy") + Path.GetExtension(file.FileName);
                            var ServerSavePath = Path.Combine(Server.MapPath("/Content/Image/") + InputFileName);
                            file.SaveAs(ServerSavePath);

                            linkAnhs.Add(new Anh() { 
                                DuongDan = "/Content/Image/" + InputFileName
                            });
                        }
                    }

                    thongTinBDS.Anhs = linkAnhs;
                    db.ThongTinBDS.Add(thongTinBDS);
                    /*db.Anhs.AddRange(linkAnhs);*/
                }
                catch (Exception)
                {

                    throw;
                }

                await db.SaveChangesAsync();
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
            thongTinBDS.Anhs = db.Anhs.Where(a => a.MaTin == thongTinBDS.MaTin).ToList();
            if (thongTinBDS == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHuong = new SelectList(db.Huongs, "MaHuong", "TenHuong", thongTinBDS.MaHuong);
            ViewBag.MaKhuDanCu = new SelectList(db.KhuDanCus, "MaKhuDanCu", "TenKhuDanCu", thongTinBDS.MaKhuDanCu);
            ViewBag.MaLoai = new SelectList(db.LoaiBDS, "MaLoai", "TenLoai", thongTinBDS.MaLoai);
            ViewBag.MaQuanHuyen = new SelectList(db.QuanHuyens, "MaQuanHuyen", "TenQuanHuyen", thongTinBDS.MaQuanHuyen);
            return View(thongTinBDS);
        }

        // POST: Admin/ThongTinBDS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
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
            ThongTinBDS thongTinBDS = db.ThongTinBDS.Where(tt => tt.MaTin == id).Include(tt => tt.Anhs).FirstOrDefault();
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
            ThongTinBDS thongTinBDS = db.ThongTinBDS.Where(tt => tt.MaTin == id).FirstOrDefault();

            ICollection<Anh> listAnh = db.Anhs.Where(a => a.MaTin == thongTinBDS.MaTin).ToList();

            for (int i = 0; i < listAnh.Count(); i++)
            {
                string path = listAnh.ElementAt(i).DuongDan;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

            }
            db.Anhs.RemoveRange(listAnh);
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
