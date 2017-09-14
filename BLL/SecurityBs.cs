using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace BLL
{
    public class SecurityBs : BaseBs
    {
        public void CreateUserIfDoesNotExist(string userEmail)
        {
            GamesJournalMembershipProvider MSP = new GamesJournalMembershipProvider();
            MSP.CreateUserIfDoesNotExist(userEmail, UserBs);
        }
    }
    public class GamesJournalMembershipProvider : MembershipProvider
    {
        userDb UsrDb;
        public GamesJournalMembershipProvider()
        {
            UsrDb = new userDb();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return "^.*(?=.{6,})(?=.*\\d).*$"; }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
        //Login
        public override bool ValidateUser(string loginKey, string password)
        {
            int count = UsrDb.GetALL().Where(x => (x.email == loginKey || x.username == loginKey)
                && BOL.StringCipher.verifyHashedPassword(x.password, password)).Count();
            if (count != 0)
                return true;
            else
                return false;
        }
        internal void CreateUserIfDoesNotExist(string userEmail, userBs userBs)
        {
            if (userBs.GetALL().Where(x => x.email == userEmail).Count() == 0)
            {
                user u = new user();
                u.profile_picture = Imgator.ImageToByte(Imgator.getDefaultProfilePicture());
                u.name = "Dummy User";
                u.username = userEmail;
                u.email = userEmail;
                u.mobile = "01234567890";
                u.password = "123456";
                u.confirmPassword = "123456";
                u.type = userTypesEn.User;
                u.active = 1;
                u.password = StringCipher.hashPassword(u.password);
                userBs.Insert(u);
            }
        }
    }
    public class GamesJournalRoleProvider : RoleProvider
    {
        userDb usrDb;

        public GamesJournalRoleProvider()
        {
            usrDb = new userDb();
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string userUniqueKey)
        {
            int[] userTypeInt = { usrDb.GetALL().Where(x => (x.email == userUniqueKey || x.username == userUniqueKey 
                    || x.id.ToString() == userUniqueKey) ).FirstOrDefault().type };

            user_typeDb usrTypeDb = new user_typeDb();
            user_type userType = usrTypeDb.GetByID(userTypeInt[0]);

            string[] s = new string[1];
            s[0] = userType.type;

            return s;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
