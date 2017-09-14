using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesJournal.Areas.Common.Controllers
{
    public class BaseCommonController : Controller
    {
        protected CommonAreaBs objBs;
        public BaseCommonController()
        {
            objBs = new CommonAreaBs();
        }
    }
}