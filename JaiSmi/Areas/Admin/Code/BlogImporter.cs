using JaiSmi.Code.Util;
using JaiSmi.DAL.EntityModel;
using JaiSmi.DAL.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace JaiSmi.Areas.Admin.Code
{
    public class BlogImporter
    {
        #region Private Variables

        private string blogFeedUrl;
        private XNamespace atomNameSpace;
        private HttpWebRequest request;
        

        #endregion

        #region Constructors

        public BlogImporter()
        {
            blogFeedUrl = System.Configuration.ConfigurationManager.AppSettings["blogFeedUrl"];
            atomNameSpace = XNamespace.Get("http://www.w3.org/2005/Atom");
        }

        #endregion

        #region Methods

        public void ImportBlogs()
        {
            request = (HttpWebRequest)WebRequest.Create(blogFeedUrl);
            request.BeginGetResponse(new AsyncCallback(GetResponse), null);
        }

        private void GetResponse(IAsyncResult result)
        {
            string feedContent = null;

            using (var response = request.EndGetResponse(result) as HttpWebResponse)
            {
                Stream responseStream = response.GetResponseStream();
                using (var reader = new StreamReader(responseStream))
                {
                    feedContent = reader.ReadToEnd();
                }
                response.Close();
            }

            if (feedContent != null)
            {
                XDocument xDoc = XDocument.Parse(feedContent);
                using (var context = new SJEntities())
                {
                    var lastPublishedDate = context.BLOGS.Max(b => b.ADDED_DATE) ?? DateTime.MinValue;

                    var posts = (from b in xDoc.Root.Descendants("item")
                                 let pubDate = DataCast.ToDateTime(b.Element("pubDate").Value)
                                 where pubDate > lastPublishedDate
                                 orderby pubDate
                                 select new BLOG
                                 {
                                     BLOG_TITLE = b.Element("title").Value,
                                     BLOG_CONTENT = b.Element("description").Value,
                                     BLOG_CONTENT_OVERVIEW = Utility.TrimContent(Utility.StripHTML(b.Element("description").Value), BlogHelper.MaxOverviewContentLength, ".", true),
                                     BLOG_URL = UrlMapper.CreateBlogUrl(Utility.TrimContent(b.Element("title").Value, BlogHelper.MaxBlogUrlLength, " ")),
                                     BLOG_ORIGINAL_URL = b.Element("link").Value,
                                     ADDED_DATE = pubDate,
                                     UPDATED_DATE = DataCast.ToDateTime(b.Element(atomNameSpace + "updated").Value)
                                 }).ToList();

                    context.BLOGS.AddRange(posts);
                    context.SaveChanges();
                }
            }
        }        

        #endregion
    }
}