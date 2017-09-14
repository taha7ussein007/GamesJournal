using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;
using System.Net;
using PagedList;
using System.Threading.Tasks;

namespace GamesJournal.Areas.Common.Controllers
{
    public class BrowseArticlesController : BaseCommonController
    {
        //
        // GET: /Common/BrowseArticle/

        [AllowAnonymous]
        public ActionResult Index(string SortOrder, string SortBy, string currentFilter, string searchString,string filterString, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var articles = objBs.ArticleBs.GetALL().Where(x => x.state == 2);


            /////////  search 
            if (searchString != null)
            {
                Page = "1";
            }
            else
            {
                searchString = SortBy;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(s => s.title.Contains(searchString) || s.content.Contains(searchString) || s.user.name.Contains(searchString) || s.article_type.category.Contains(searchString));
            }

         ///////////////////////////////////

            ////////////////// filter 

            var artcls = new SelectList(
                objBs.ArticleBs.GetALL().Select(r => r.article_type.category).Distinct().ToList());

            ViewBag.filterString = artcls;

            ViewBag.FILTER = filterString;

            if (!String.IsNullOrEmpty(filterString))
            {
                articles = articles.Where(s => s.article_type.category == filterString);
            }

            /////////////

            switch (SortBy)
            {
                case "title":
                    switch (SortOrder)
                    {

                        case "Asc":
                            articles = articles.OrderBy(x => x.title).ToList();
                            break;
                        case "Desc":
                            articles = articles.OrderByDescending(x => x.title).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "category":
                    switch (SortOrder)
                    {

                        case "Asc":
                            articles = articles.OrderBy(x => x.article_type.category).ToList();
                            break;
                        case "Desc":
                            articles = articles.OrderByDescending(x => x.article_type.category).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "rating":
                    switch (SortOrder)
                    {

                        case "Asc":
                            articles = articles.OrderBy(x => x.rating).ToList();
                            break;
                        case "Desc":
                            articles = articles.OrderByDescending(x => x.rating).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Date&Time":
                    switch (SortOrder)
                    {

                        case "Asc":
                            articles = articles.OrderBy(x => x.timestamp).ToList();
                            break;
                        case "Desc":
                            articles = articles.OrderByDescending(x => x.timestamp).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "content":
                    switch (SortOrder)
                    {

                        case "Asc":
                            articles = articles.OrderBy(x => x.content).ToList();
                            break;
                        case "Desc":
                            articles = articles.OrderByDescending(x => x.content).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "author":
                    switch (SortOrder)
                    {

                        case "Asc":
                            articles = articles.OrderBy(x => x.author).ToList();
                            break;
                        case "Desc":
                            articles = articles.OrderByDescending(x => x.author).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    articles = articles.OrderBy(x => x.title).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.ArticleBs.GetALL().Where(x => x.state == 2).Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            articles = articles.Skip((page - 1) * 10).Take(10);

            return View(articles);
        }

        public FileResult ExportTo(string ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/GmsJournReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "articleDataSet";
            reportDataSource.Value = objBs.ArticleBs.GetALL().Where(x => x.state == 2).ToList();

            localReport.DataSources.Add(reportDataSource);

            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtension = (ReportType == "Excel") ? "xlsx" : (ReportType == "Word" ? "doc" : "pdf");
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = localReport.Render(reportType, "", out mimeType, out encoding,
                                                out fileNameExtension, out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment; filename=Articles." + fileNameExtension);

            return File(renderedBytes, fileNameExtension);

        }



        [Authorize(Roles = "Chief Editor,Editor")]
        public ActionResult Delete(int id)
        {

            try
            {
                objBs.ArticleBs.Delete(id);
                TempData["Msg"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Delete Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }




        [HttpGet]
        [Authorize(Roles = "Chief Editor,Editor")]
        public ActionResult Edit(int Id)
        {
            var article = objBs.ArticleBs.GetByID(Id);
            return View(article);
        }

        [HttpPost]
        [Authorize(Roles = "Chief Editor,Editor")]
        public ActionResult Edit(article art)
        {
            try
            {
                ModelState.Remove("title");
                if (ModelState.IsValid)
                {
                    var article = objBs.ArticleBs.GetByID(art.id);
                    article.title = art.title;
                    article.content = art.content;
                    article.state = art.state;
                    article.category = art.category;
                    article.author = art.author;
                    article.views = art.views;
                    article.rate_count = art.rate_count;
                    article.rating = art.rating;
                    article.link = art.link;
                    article.timestamp = DateTime.Now;

                    objBs.ArticleBs.Update(article);
                    TempData["Msg"] = "Updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Edit");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed : " + e1.Message;
                return RedirectToAction("Edit");
            }
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            article art = objBs.ArticleBs.GetByID(id);
            if (art == null)
            {
                return HttpNotFound();
            }
            art.views++;
            objBs.ArticleBs.Update(art);
            return View("viewArticle", art);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Comment(int artID, string content)
        {
            var art = objBs.ArticleBs.GetByID(artID);
            await Task.Run(() => 
            {
                try
                {
                    var comment = new comment();
                    comment.article_id = art.id;
                    comment.content = content;
                    comment.user_id = objBs.UserBs.GetByLoginKey(User.Identity.Name).id;
                    comment.timestamp = DateTime.Now;
                    if (!String.IsNullOrEmpty(comment.content))
                        objBs.CommentBs.Insert(comment);
                }
                catch (Exception)
                {
                }
            });
            return PartialView("pv_comments", art);
        }

        [Authorize]
        public async Task<ActionResult> Rate(article art, int rateVal)
        {
            await Task.Run(() =>
            {
                //TODO
            });
            return PartialView("viewname", art);
        }
     
    }
}