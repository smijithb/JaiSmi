using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaiSmi.Areas.Blog.Models
{
    public class BlogResultModel
    {
        public bool IsSuccess { get; set; }
        public string UrlToRedirect { get; set; }
        public string ErrorMessage { get; set; }
    }
}