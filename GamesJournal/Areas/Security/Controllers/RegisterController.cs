using BOL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GamesJournal.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class RegisterController : BaseSecurityController
    {
        //
        // GET: /Security/Register/
        public ActionResult Index()
        {
            return View();
        }

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
                    TempData["Msg"] = "Created Successfully, You Can Login Now ☺";

                    //Auto SignIn After SignUp ??

                    return RedirectToAction("Index", new { Controller = "Login", Area = "Security" });
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