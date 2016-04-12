using JaiSmi.DAL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaiSmi.Areas.Blog.Models
{
    public class BlogPostDetailsModel
    {
        public BlogPostModel BlogPostModel { get; set; }

        public BlogPostDetailsModel(string url)
        {
            BlogPostModel = BlogHelper.GetBlogPost(url);
        }
    }
}