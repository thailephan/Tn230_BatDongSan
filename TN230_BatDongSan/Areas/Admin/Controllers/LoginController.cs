using System.Web.Mvc;
using System.Web.Security;
using TN230_BatDongSan.Areas.Admin.Models;

namespace TN230_BatDongSan.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            //var result = new ModelsMVC.AccountModel().Login(model.UserName, model.Password);
            if (Membership.ValidateUser(model.Username, model.Password) && ModelState.IsValid)
            {
                //Nếu thành công chúng ta cần tạo session
                //SessionHelper.SetSession(new UserSession(model.UserName));
                FormsAuthentication.SetAuthCookie(model.Username, model.Rememberme);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc Password không đúng!");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}
