using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesJournal.Areas.ChiefEditor.Controllers
{
    [Authorize(Roles="Chief Editor")]
    public class ApproveArticlesController : BaseChiefEditorController
    {
        // GET: ChiefEditor/ApproveArticles
        public ActionResult Index(string Status)
        {
            ViewBag.Status = (Status == null ? articleStateEn.PendingStr : Status);
            if (Status == null)
            {
                var articles = objBs.ArticleBs.GetALL().Where(x => x.state == articleStateEn.Pending).ToList();
                return View(articles);
            }
            else
            {
                var urls = objBs.ArticleBs.GetALL().Where(x => x.state == articleStateEn.GetEquivelant(Status)).ToList();
                return View(urls);
            }
        }

        public ActionResult Approve(int id)
        {
            try
            {
                var myArticle = objBs.ArticleBs.GetByID(id);
                myArticle.state = articleStateEn.Approved;
                objBs.ArticleBs.Update(myArticle);
                TempData["Msg"] = "Approved Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Approval Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
        public ActionResult Reject(int id)
        {
            try
            {
                var myArticle = objBs.ArticleBs.GetByID(id);
                myArticle.state = articleStateEn.Refused;
                objBs.ArticleBs.Update(myArticle);
                TempData["Msg"] = "Rejected Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Rejection Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult ApproveOrRejectALL(List<int> Ids, String Status, string CurrentStatus)
        {
            try
            {
                objBs.ApproveOrReject(Ids, Status);
                TempData["Msg"] = "Operation Successfully";
                var articles = objBs.ArticleBs.GetALL().Where(x => x.state == articleStateEn.GetEquivelant(CurrentStatus)).ToList();
                return PartialView("pv_ApproveArticles", articles);
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Operation Failed : " + e1.Message;
                TempData["Msg"] += "\nPlease Make Sure To Select Articles First.";
                var articles = objBs.ArticleBs.GetALL().Where(x => x.state == articleStateEn.GetEquivelant(CurrentStatus)).ToList();
                return PartialView("pv_ApproveArticles", articles);
            }
        }
    }
}