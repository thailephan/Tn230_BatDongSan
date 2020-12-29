using System.Web.Mvc;

namespace TN230_BatDongSan.Areas.Admin.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Admin/Error
        public ActionResult NotFoundPage()
        {
            return View();
        }
    }
}