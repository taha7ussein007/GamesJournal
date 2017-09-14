using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL;

namespace GamesJournal.Areas.User.Controllers
{
    [Authorize]
    public class FeedbackController : BaseUserController
    {
        // GET: User/Feedback
        public ActionResult Index()
        {
            return View(); //new userBs().GetByLoginKey(User.Identity.Name)
        }

        [HttpPost]
        public ActionResult Create(feedback feedback)
        {
            var u_ID = new userBs().GetByLoginKey(User.Identity.Name).id;
            feedback.user_id = u_ID;
            try
            {
                if (ModelState.IsValid)
                {
                    objBs.FeedbackBs.Insert(feedback);
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