using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DbContextModel.Framework;

namespace TN230_BatDongSan.Controllers
{
    public class ThongTinsController : Controller
    {
        private DbContextWeb db = new DbContextWeb();

        // GET: /ThongTins
        public ActionResult Index()
        {
            var thongTins = db.ThongTins.Include(t => t.TaiKhoan);
            return View(thongTins.ToList());
        }

        // GET: /ThongTins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTin thongTin = db.ThongTins.Find(id);
            if (thongTin == null)
            {
                return HttpNotFound();
            }
            return View(thongTin);
        }
    }
}
