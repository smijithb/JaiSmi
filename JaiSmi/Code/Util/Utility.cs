using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace JaiSmi.Code.Util
{
    public class Utility
    {
        private static Regex htmlTags = new Regex("<[^>]*(>|$)", RegexOptions.Singleline | RegexOptions.ExplicitCapture | RegexOptions.Compiled);

        public  static string StripHTML(string html)
        {
            MatchCollection tags = htmlTags.Matches(html);
            Match tag;
            string tagname;

            for (int i = tags.Count - 1; i > -1; i--)
            {
                tag = tags[i];
                tagname = tag.Value.ToLowerInvariant();
                html = html.Remove(tag.Index, tag.Length);
            }

            html = html.Replace("&nbsp;", "").Trim();
            return html;
        }

        public  static string TrimContent(string text, int length, string delimiter, bool appendWithDots = false)
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (text.Length > length)
                {
                    string strContent = text.Substring(0, length);
                    if (text.LastIndexOf(delimiter) >= length - 1)
                    {
                        string remainingText = text.Substring(length);
                        int whiteSpaceIndex = remainingText.IndexOf(delimiter);
                        text = string.Concat(strContent, remainingText.Substring(0, whiteSpaceIndex), (appendWithDots ? "..." : ""));
                    }
                }
            }
            return text;
        }
    }
}