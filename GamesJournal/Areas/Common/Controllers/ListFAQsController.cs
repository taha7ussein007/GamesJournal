using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using System.Net;

namespace GamesJournal.Areas.Common.Controllers
{
    public class ListFAQsController : BaseCommonController
    {
        // GET: Common/ListFAQs
 
        [Authorize]
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var FAQs = objBs.FaqBs.GetALL();

            switch (SortBy)
            {
                case "question":
                    switch (SortOrder)
                    {

                        case "Asc":
                            FAQs = FAQs.OrderBy(x => x.question).ToList();
                            break;
                        case "Desc":
                            FAQs = FAQs.OrderByDescending(x => x.question).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "answer":
                    switch (SortOrder)
                    {

                        case "Asc":
                            FAQs = FAQs.OrderBy(x => x.answer).ToList();
                            break;
                        case "Desc":
                            FAQs = FAQs.OrderByDescending(x => x.answer).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Date&Time":
                    switch (SortOrder)
                    {

                        case "Asc":
                            FAQs = FAQs.OrderBy(x => x.q_timestamp).ToList();
                            break;
                        case "Desc":
                            FAQs = FAQs.OrderByDescending(x => x.q_timestamp).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    FAQs = FAQs.OrderBy(x => x.question).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.FaqBs.GetALL().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            FAQs = FAQs.Skip((page - 1) * 10).Take(10);

            return View(FAQs);
        }


        [Authorize(Roles = "Chief Editor,Editor")]
        public ActionResult Delete(int id)
        {

            try
            {
                objBs.FaqBs.Delete(id);
                TempData["Msg"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Delete Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }



        [Authorize(Roles = "Chief Editor,Editor")]
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var faq = objBs.FaqBs.GetByID(Id);
            return View(faq);
        }

        [Authorize(Roles = "Chief Editor,Editor")]
        [HttpPost]
        public ActionResult Update(faq Faq)
        {
            try
            {
                ModelState.Remove("question");
                if (ModelState.IsValid)
                {
                    var FAQ = objBs.FaqBs.GetByID(Faq.id);
                    FAQ.answer = Faq.answer;
                    FAQ.a_timestamp = DateTime.Now;
                    FAQ.respondent_id = objBs.UserBs.GetByLoginKey(User.Identity.Name).id;
                    objBs.FaqBs.Update(FAQ);
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

        [Authorize(Roles = "Chief Editor,Editor")]
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faq fq = objBs.FaqBs.GetByID(id);
            if (fq == null)
            {
                return HttpNotFound();
            }
            return View(fq);
        }
    }
}