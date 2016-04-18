using JaiSmi.Code.Util;
using JaiSmi.DAL.Helpers;
using JaiSmi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaiSmi.Areas.Blog.Models
{
    public class BlogModel
    {
        public List<BlogOverviewModel> BlogOverviews { get; set; }
        public string CreateNewPostUrl { get { return UrlMapper.FormatCreateNewBlogPostUrl();  } }

        public BlogModel()
        {
            BlogOverviews = BlogHelper.GetBlogOverviews(int.MaxValue);
        }
    }
}