using BOL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GamesJournal.Areas.Security.Controllers
{
    [Authorize]
    public class AccountController : BaseSecurityController
    {
        // GET: Common/Account
        public ActionResult Index()
        {
            var currentUser = 
                objBs.UserBs.GetByLoginKey(User.Identity.Name);
            var updateUser = new userUpdate();
            var dummyUsr = updateUser + currentUser;
            return View(updateUser);
        }

        [HttpPost]
        public async Task<ActionResult> Update(userUpdate updateUser)
        {
            var currentUser = 
                objBs.UserBs.GetByLoginKey(User.Identity.Name);
            try
            {
                await Task.Run(() => 
                {
                    #region Check Password Ver.
                    if (String.IsNullOrEmpty(updateUser.PasswordVerfication))
                        throw new Exception("Update Failed! You Must Enter Correctly Your Current Password In Order To Update Your Info.");
                    if (!StringCipher.verifyHashedPassword(currentUser.password, updateUser.PasswordVerfication))
                        throw new Exception("Update Failed! You Must Enter Correctly Your Current Password In Order To Update Your Info.");
                    #endregion
                });
                if (ModelState.IsValid)
                {
                    await Task.Run(() =>
                    {
                        objBs.UserBs.Update(currentUser + updateUser);
                        TempData["Msg"] = "Updated Successfully";
                    });
                    return RedirectToAction("Index", updateUser);
                }
                else
                {
                    await Task.Run(() =>
                    {
                        TempData["Msg"] = "Update Failed!";
                        var tmp = updateUser + currentUser; //tmp cuz i cannot overload operator= :(
                    });
                    return RedirectToAction("Index", updateUser);
                }
            }
            catch(Exception ex)
            {
                TempData["Msg"] = "Update Failed: " + ex.Message;
                var tmp = updateUser + currentUser; //again tmp cuz i cannot overload operator= xD
                return RedirectToAction("Index", currentUser);
            }
        }
    }
}