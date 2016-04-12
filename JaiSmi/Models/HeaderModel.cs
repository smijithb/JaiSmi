using JaiSmi.Code.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaiSmi.Models
{
    public class HeaderModel
    {
        public string HomeUrl { get { return "/"; } }
        public string BlogUrl { get { return UrlMapper.BlogBaseUrl; } }
        public string TravelDiariesUrl { get { return UrlMapper.TravelDiariesBaseUrl; } }
        public string KidsCoUrl { get { return UrlMapper.KidsCoUrl; } }
    }
}