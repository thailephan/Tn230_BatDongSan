using System.Linq;
using System.Net;
using System.Web.Mvc;
using DbContextModel.Framework;

namespace TN230_BatDongSan.Areas.Admin.Controllers
{
    public class AnhsController : Controller
    {
        private DbContextWeb db = new DbContextWeb();

        // GET: Admin/Anhs
        public ActionResult Index()
        {
            return View(db.Anhs.ToList());
        }

        // GET: Admin/Anhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anh anh = db.Anhs.Find(id);
            if (anh == null)
            {
                return HttpNotFound();
            }
            return View(anh);
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
