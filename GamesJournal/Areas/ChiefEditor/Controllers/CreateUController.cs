using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesJournal.Areas.ChiefEditor.Controllers
{
    [AllowAnonymous]
    public class CreateUController : Controller
    {
        // GET: ChiefEditor/CreateU
        public ActionResult Index()
        {
            return View();
        }
    }
}