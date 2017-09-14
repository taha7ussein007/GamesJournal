using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace GamesJournal.Areas.ChiefEditor.Controllers
{
    [Authorize(Roles = "Chief Editor")]
    public class ListuserController : BaseChiefEditorController
    {
        // GET: ChiefEditor/Listuser
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var user = objBs.UserBs.GetALL();

            #region SwitchCase
            switch (SortBy)
            {
                case "name":
                    switch (SortOrder)
                    {

                        case "Asc":
                            user = user.OrderBy(x => x.name).ToList();
                            break;
                        case "Desc":
                            user = user.OrderByDescending(x => x.name).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "email":
                    switch (SortOrder)
                    {

                        case "Asc":
                            user = user.OrderBy(x => x.email).ToList();
                            break;
                        case "Desc":
                            user = user.OrderByDescending(x => x.email).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "type":
                    switch (SortOrder)
                    {

                        case "Asc":
                            user = user.OrderBy(x => x.user_type.type).ToList();
                            break;
                        case "Desc":
                            user = user.OrderByDescending(x => x.user_type.type).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    user = user.OrderBy(x => x.name).ToList();
                    break;
            }
            #endregion

            ViewBag.TotalPages = Math.Ceiling(objBs.UserBs.GetALL().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            user = user.Skip((page - 1) * 10).Take(10).ToList();

            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var user = objBs.UserBs.GetByID(Id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(user U)
        {
            try
            {
                ModelState.Remove("email");
                if (ModelState.IsValid)
                {
                    var user = objBs.UserBs.GetByID(U.id);
                    user.email = U.email;
                    user.user_type.type = U.user_type.type;
                    user.password = U.password;
                    user.active = U.active;
                    user.mobile = U.mobile;
                    objBs.UserBs.Update(user);
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


        public ActionResult Delete(int id)
        {

            try
            {
                objBs.UserBs.Delete(id);
                TempData["Msg"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Delete Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user us = objBs.UserBs.GetByID(id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Create(user _user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _user.type = userTypesEn.User;
                    _user.active = 1;
                    _user.password = StringCipher.hashPassword(_user.password);
                    _user.confirmPassword = _user.password;
                    await Task.Run(() =>
                    {
                        try
                        {
                            MemoryStream imgStream = new MemoryStream();
                            _user.ProfileImage.InputStream.CopyTo(imgStream);
                            _user.profile_picture = Imgator.ImageToByte(new Bitmap(imgStream));
                        }
                        catch
                        {
                            while (_user.profile_picture == null)
                                _user.profile_picture = Imgator.ImageToByte(Imgator.getDefaultProfilePicture());
                        }
                    });
                    objBs.UserBs.Insert(_user);
                    TempData["Msg"] = "Created Successfully";

                    //Auto SignIn After SignUp ??

                    return RedirectToAction("Index"); //new { Controller = "Login", Area = "Security" }
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