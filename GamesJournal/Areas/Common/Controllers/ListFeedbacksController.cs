using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL;

namespace GamesJournal.Areas.Common.Controllers
{
    public class ListFeedbacksController : BaseCommonController
    {
        // GET: Common/ListFeedbacks
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var feedbacks = objBs.FeedbackBs.GetALL();

            switch (SortBy)
            {

                case "content":
                    switch (SortOrder)
                    {

                        case "Asc":
                            feedbacks = feedbacks.OrderBy(x => x.content).ToList();
                            break;
                        case "Desc":
                            feedbacks = feedbacks.OrderByDescending(x => x.content).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    feedbacks = feedbacks.OrderBy(x => x.id).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.FeedbackBs.GetALL().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            feedbacks = feedbacks.Skip((page - 1) * 10).Take(10);

            return View(feedbacks);
        }

        public ActionResult Delete(int id)
        {

            try
            {
                objBs.FeedbackBs.Delete(id);
                TempData["Msg"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Delete Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }





    }
}