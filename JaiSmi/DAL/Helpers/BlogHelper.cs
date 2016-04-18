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
            if (!string.IsNullOrWhiteSpace(url))
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
            else
            {
                return GetNewBlogPost();
            }
        }

        public static BlogPostModel GetNewBlogPost()
        {
            return new BlogPostModel { Id = -1, Title = string.Empty, Content = string.Empty };
        }

        public static BlogResultModel UpdatePost(long postId, string postTitle, string postContent)
        {
            var result = new BlogResultModel();

            if (!string.IsNullOrWhiteSpace(postTitle) && !string.IsNullOrWhiteSpace(postContent))
            {
                using (var context = new SJEntities())
                {
                    var post = (from b in context.BLOGS
                                where b.BLOG_ID == postId
                                select b).FirstOrDefault();

                    if (post != null)
                    {
                        post.BLOG_TITLE = postTitle.Trim();
                        post.BLOG_CONTENT = postContent;
                        post.BLOG_CONTENT_OVERVIEW = Utility.TrimContent(Utility.StripHTML(postContent), MaxOverviewContentLength, ".", true);

                        if (post.BLOG_TITLE != postTitle)
                        {
                            post.BLOG_URL = UrlMapper.CreateBlogPostUrl(Utility.TrimContent(postTitle, BlogHelper.MaxBlogUrlLength, " "));
                            result.UrlToRedirect = UrlMapper.FormatBlogPostUrl(post.BLOG_URL);
                        }

                        //context.SaveChanges();
                        result.IsSuccess = true;
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.ErrorMessage = "No such post exists.";
                    }
                }
            }
            else
            {
                result.ErrorMessage = "Title and/or content cannot be empty.";
            }

            return result;
        }

        public static BlogResultModel InsertPost(string postTitle, string postContent)
        {
            var result = new BlogResultModel();

            if (!string.IsNullOrWhiteSpace(postTitle) && !string.IsNullOrWhiteSpace(postContent))
            {
                using (var context = new SJEntities())
                {
                    var post = new BLOG();
                    post.BLOG_TITLE = postTitle.Trim();
                    post.BLOG_CONTENT = postContent;
                    post.BLOG_CONTENT_OVERVIEW = Utility.TrimContent(Utility.StripHTML(postContent), MaxOverviewContentLength, ".", true);
                    post.BLOG_URL = UrlMapper.CreateBlogPostUrl(Utility.TrimContent(postTitle, BlogHelper.MaxBlogUrlLength, " "));
                    post.BLOG_ORIGINAL_URL = null;
                    post.ADDED_DATE = DateTime.UtcNow;
                    //post.ADDED_BY = null; // TODO: Add user id once authentication is implemented.
                    post.UPDATED_DATE = DateTime.UtcNow;
                    //post.UPDATED_BY = null; // TODO: Add user id once authentication is implemented.

                    context.BLOGS.Add(post);
                    //context.SaveChanges();
                    result.IsSuccess = true;
                    result.UrlToRedirect = UrlMapper.FormatBlogPostUrl(post.BLOG_URL);
                }
            }
            else
            {
                result.ErrorMessage = "Title and/or content cannot be empty.";
            }

            return result;
        }

        #endregion
    }
}