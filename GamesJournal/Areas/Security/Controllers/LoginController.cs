using BOL;
using Microsoft.Web.WebPages.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GamesJournal.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseSecurityController
    {
        //
        // GET: /Security/Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(userLogin _user)
        {
                try
                {
                    if (Membership.ValidateUser(_user.LoginKey, _user.Password))
                    {
                        if (_user.RememberMe)
                            FormsAuthentication.SetAuthCookie(_user.LoginKey, true);
                        else
                            FormsAuthentication.SetAuthCookie(_user.LoginKey, false);

                        return RedirectToAction("Index", "Home", new { area = "Common" });
                    }
                    else
                    {
                        TempData["Msg"] = "Login Attemp Failed!";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception E1)
                {
                    TempData["Msg"] = "Login Failed: " + E1.Message;
                    return RedirectToAction("Index");
                }
        }

        public ActionResult ExternalLogin(string provider)
        {
            OAuthWebSecurity.RequestAuthentication(provider, Url.Action("ExternalLoginCallback"));
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }
        public ActionResult ExternalLoginCallback(string provider)
        {
            var result = OAuthWebSecurity.VerifyAuthentication();

            if (result.IsSuccessful == false)
            {
                TempData["Msg"] = "Login Failed!";
                return RedirectToAction("Index");
            }
            else
            {
                objBs.CreateUserIfDoesNotExist(result.UserName);
                FormsAuthentication.SetAuthCookie(result.UserName, false);
                return RedirectToAction("Index", "Home", new { area = "Common" });
            }
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }
    }
}