using JaiSmi.Areas.Blog.Models;
using JaiSmi.Code.Util;
using JaiSmi.DAL.EntityModel;
using JaiSmi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaiSmi.DAL.Helpers
{
    public class BlogHelper
    {
        #region Private Variables

        private const int maxBlogOverviewCount = 5;

        #endregion

        #region Public Variables

        public const int MaxOverviewContentLength = 300;
        public const int MaxBlogUrlLength = 50;

        #endregion

        #region Public Methods

        public static List<BlogOverviewModel> GetBlogOverviews(int records = maxBlogOverviewCount)
        {
            using (var context = new SJEntities())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                return (from b in context.BLOGS
                        orderby b.ADDED_DATE descending
                        select new BlogOverviewModel
                        {
                            Id = b.BLOG_ID,
                            Title = b.BLOG_TITLE,
                            Content = b.BLOG_CONTENT_OVERVIEW,
                            Url = b.BLOG_URL
                        }).Take(records).ToList();
            }
        }

        public static BlogPostModel GetBlogPost(string url)
        {
            url = url.ToLowerInvariant();
            using (var context = new SJEntities())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                return (from b in context.BLOGS
                        where b.BLOG_URL == url
                        select new BlogPostModel
                        {
                            Id = b.BLOG_ID,
                            Title = b.BLOG_TITLE,
                            Content = b.BLOG_CONTENT
                        }).FirstOrDefault();
            }
        }

        public static bool UpdatePost(long postId, string postTitle, string postContent)
        {
            using (var context = new SJEntities())
            {
                var post = (from b in context.BLOGS
                            where b.BLOG_ID == postId
                            select b).FirstOrDefault();
                if (post != null)
                {
                    post.BLOG_TITLE = postTitle;
                    post.BLOG_CONTENT = postContent;
                    post.BLOG_CONTENT_OVERVIEW = Utility.TrimContent(Utility.StripHTML(postContent), MaxOverviewContentLength, ".", true);

                    //context.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        #endregion
    }
}