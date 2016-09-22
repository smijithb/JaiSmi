using JaiSmi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JaiSmi.Areas.Travel.Controllers
{
    public class TravelController : Controller
    {
        [Route("~/travel-diaries")]
        public ActionResult Index()
        {
            TravelOverviewModel model = new TravelOverviewModel();
            return View("~/Areas/Travel/Views/Index.cshtml", model);
        }
    }
}