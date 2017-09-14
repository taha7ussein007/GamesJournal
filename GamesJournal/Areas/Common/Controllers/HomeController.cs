using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesJournal.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseCommonController
    {
        // GET: Common/Home
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
                return View(this.objBs.UserBs.GetByLoginKey(User.Identity.Name));
            return View();
        }
    }
}