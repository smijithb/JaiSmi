using JaiSmi.Areas.Admin.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JaiSmi.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        [Route("admin/blog/import")]
        public ActionResult Index()
        {
            return View("~/Areas/Admin/Views/Admin/Blog/ImportPosts.cshtml");
        }

        public ActionResult Insert()
        {
            BlogImporter importer = new BlogImporter();
            importer.ImportBlogs();
            return View("~/Areas/Admin/Views/Admin/Blog/ImportPosts.cshtml");
        }
    }
}