using JaiSmi.DAL.EntityModel;
using JaiSmi.DAL.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JaiSmi.Models
{
    public class HomeModel
    {
        public string AboutMe { get; set; }
        public List<BlogOverviewModel> BlogOverviews { get; set; }

        public HomeModel()
        {
            BlogOverviews = BlogHelper.GetBlogOverviews();
        }
    }
}