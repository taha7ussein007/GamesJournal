using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace GamesJournal.Areas.User.Controllers
{
    public class BaseUserController : Controller
    {
        // GET: User/BaseUser
        protected BaseBs objBs;
        public BaseUserController()
        {
            objBs = new BaseBs();
        }
    }
}