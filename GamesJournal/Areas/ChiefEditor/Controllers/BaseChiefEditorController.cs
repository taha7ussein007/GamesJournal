using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesJournal.Areas.ChiefEditor.Controllers
{
    public class BaseChiefEditorController : Controller
    {
       protected ChiefEditorBs objBs;
       public BaseChiefEditorController()
        {
            objBs = new ChiefEditorBs();
        }
    }
}