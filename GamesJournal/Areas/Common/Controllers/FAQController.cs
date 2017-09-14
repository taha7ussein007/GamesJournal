using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace GamesJournal.Areas.Common.Controllers
{
    public class FAQController : BaseCommonController
    {
        // GET: Common/FAQ
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(faq FAQ)
        {
            try
            {
                FAQ.q_timestamp = DateTime.Now;
                FAQ.asker_id = objBs.UserBs.GetByLoginKey(User.Identity.Name).id;
                if (ModelState.IsValid)
                {
                    objBs.FaqBs.Insert(FAQ);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}