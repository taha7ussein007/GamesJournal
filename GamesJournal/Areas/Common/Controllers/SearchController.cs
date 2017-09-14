using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesJournal.Areas.Common.Controllers
{
    public class SearchController : BaseCommonController
    {
        // GET: Common/Search
        public ActionResult Index()
        {
            return View();
        }
    }
}