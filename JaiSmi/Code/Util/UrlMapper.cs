using JaiSmi.DAL.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace JaiSmi.Code.Util
{
    public class UrlMapper
    {
        private static Regex validUrl = new Regex("[^a-zA-Z0-9 ]+");

        public const string BlogBaseUrl = "/blog/";
        public const string BlogPostBaseUrl = "/blog/post/";
        public const string TravelDiariesBaseUrl = "/travel-diaries/";
        public const string KidsCoUrl = "/kids-corner/";

        public static string CreateBlogPostUrl(string blogTitle)
        {
            using (var context = new SJEntities())
            {
                var blogUrls = (from b in context.BLOGS
                                select b.BLOG_URL).ToList();

                var url = validUrl.Replace(blogTitle, "").Replace(' ', '-').ToLowerInvariant();

                return GetUniqueUrl(url, blogUrls);
            }
        }

        public static string FormatBlogPostUrl(string blogUrl)
        {
            return string.Format("{0}{1}", BlogPostBaseUrl, blogUrl);
        }

        public static string FormatCreateNewBlogPostUrl()
        {
            return BlogPostBaseUrl;
        }

        private static string GetUniqueUrl(string url, List<string> existingUrls, int counter = 0)
        {
            if (existingUrls.Contains(url))
                GetUniqueUrl(string.Format("{0}-{1}", url, counter), existingUrls, counter++);

            return url;
        }
    }
}