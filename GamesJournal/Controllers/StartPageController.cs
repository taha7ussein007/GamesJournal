using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesJournal.Controllers
{
    [AllowAnonymous]
    public class StartPageController : Controller
    {
        // GET: StartPage
        public ActionResult StartPage()
        {
            return View("StartPage");
        }
    }
}