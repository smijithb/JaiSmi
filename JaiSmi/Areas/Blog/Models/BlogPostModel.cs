using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaiSmi.Areas.Blog.Models
{
    public class BlogPostModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}