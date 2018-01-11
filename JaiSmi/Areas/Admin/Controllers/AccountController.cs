using JaiSmi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JaiSmi.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        [Route("admin/login")]
        public ActionResult Login()
        {
            return View("~/Areas/Admin/Views/Account/Login.cshtml");
        }

        [Route("admin/signup")]
        public ActionResult Signup()
        {
            return View("~/Areas/Admin/Views/Account/Signup.cshtml");
        }

        [Route("admin/authenticate")]
        [HttpPost]
        public ActionResult Authenticate(string emailAddress, string password)
        {
            return RedirectToAction("Home", "Account");
        }

        [Route("admin/createuser")]
        [HttpPost]
        public ActionResult CreateUser(UserModel model)
        {
            return RedirectToAction("Home", "Account");
        }

        [Route("admin/home")]
        public ActionResult Home()
        {
            return View("~/Areas/Admin/Views/Account/Home.cshtml");
        }
    }
}