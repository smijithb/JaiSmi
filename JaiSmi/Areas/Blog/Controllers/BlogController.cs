using JaiSmi.Areas.Blog.Models;
using JaiSmi.DAL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JaiSmi.Areas.Blog.Controllers
{
    public class BlogController : Controller
    {
        [Route("~/blog")]
        public ActionResult Index()
        {
            BlogModel model = new BlogModel();
            return View("~/Areas/Blog/Views/Index.cshtml", model);
        }

        [Route("~/blog/post/{url:regex(^[a-zA-Z0-9-]+$)}")]
        public ActionResult BlogPost(string url)
        {
            BlogPostDetailsModel model = new BlogPostDetailsModel(url);
            return View("~/Areas/Blog/Views/BlogPost.cshtml", model);
        }

        [HttpPost]
        [Route("~/blog/post/update")]
        public bool Update(long postId, string postTitle, string postContent)
        {
            return BlogHelper.UpdatePost(postId, HttpUtility.UrlDecode(postTitle), HttpUtility.UrlDecode(postContent));
        }
    }
}