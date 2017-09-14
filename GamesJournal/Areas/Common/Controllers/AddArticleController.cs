using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GamesJournal.Areas.Common.Controllers
{
    [Authorize(Roles = "Chief Editor, Editor, User" )]
    public class AddArticleController : BaseCommonController
    {
        // GET: Common/AddArticle
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(article _article)
        {
            try
            {
                await Task.Run(() => 
                {
                    _article.state = articleStateEn.Pending;
                    _article.author = 
                        objBs.UserBs.GetByLoginKey(User.Identity.Name).id;
                    if (objBs.UserBs.GetByLoginKey(User.Identity.Name).type ==
                        userTypesEn.ChiefEditor)
                        _article.state = articleStateEn.Approved;
                    _article.timestamp = DateTime.Now;

                    if (ModelState.IsValid)
                    {
                        objBs.ArticleBs.Insert(_article);
                        TempData["Msg"] = "Added Successfully ☺";
                    }
                    else
                        throw new Exception("Invalid Article! Please Check [Title, Content, etc...]");
                });
                return RedirectToAction("Index", new { Controller = "BrowseArticles", Area = "Common" });
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Create Failed: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}