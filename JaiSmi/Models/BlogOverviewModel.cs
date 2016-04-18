using JaiSmi.Code.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaiSmi.Models
{
    public class BlogOverviewModel
    {
        #region Private Variables

        private string url;

        #endregion

        #region Properties

        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url
        {
            get { return UrlMapper.FormatBlogPostUrl(url); }
            set { url = value; }
        }

        #endregion
    }
}