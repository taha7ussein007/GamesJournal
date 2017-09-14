using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace BOL
{
    public class userUpdate
    {
        #region Potential update attribtes
        public int Role { get; set; }
        public string Password { get; set; }
        public byte[] updateProfilePicture { get; set; }
        public HttpPostedFileBase updateProfileImage { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression(@"^(([a-zA-Z]{2,}[ ])+([a-zA-Z]{2,})+)+$", ErrorMessage = "User Name Is Not Valid Full Name!")]
        [Display(Name = "Full Name")]
        public string updateName { get; set; }

        [Required]
        [EmailAddress]
        public string updateEmail { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Entered mobile format is not valid.")]
        public string updateMobile { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MembershipPassword(
        MinRequiredNonAlphanumericCharacters = 1,
        MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
        ErrorMessage = "Your password must be 6 characters long contains at least one digit and one symbol (!, @, #, etc).",
        MinRequiredPasswordLength = 6)]
        public string updatePassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("updatePassword")]
        public string confirmUpdatePassword { get; set; }

        [Required(ErrorMessage = "Password Verfication Is Required")]
        [DataType(DataType.Password)]
        public string PasswordVerfication { get; set; }

        #endregion

        public static user operator +(userUpdate uup, user u)
        {
            uup.Role = u.type;

            if(String.IsNullOrEmpty(uup.updateName))
                uup.updateName = u.name;
            else
                u.name = uup.updateName;

            if (String.IsNullOrEmpty(uup.updateEmail))
                uup.updateEmail = u.email;
            else
                u.email = uup.updateEmail;

            if (String.IsNullOrEmpty(uup.updateMobile))
                uup.updateMobile = u.mobile;
            else
                u.mobile = uup.updateMobile;

            if (String.IsNullOrEmpty(uup.updatePassword))
            {
                uup.updatePassword = u.password;
                uup.confirmUpdatePassword = u.password;
                uup.Password = u.password;
                u.confirmPassword = u.password;
            }
            else if (uup.updatePassword == u.password)
            {
                uup.updatePassword = u.password;
                uup.confirmUpdatePassword = u.password;
                uup.Password = u.password;
                u.confirmPassword = u.password;
            }
            else
            {
                u.password = StringCipher.hashPassword(uup.updatePassword);
                uup.updatePassword = u.password;
                uup.confirmUpdatePassword = u.password;
                uup.Password = u.password;
                u.confirmPassword = u.password;
            }

            if (uup.updateProfileImage == null)
                uup.updateProfilePicture = u.profile_picture;
            else
            {
                MemoryStream imgStream = new MemoryStream();
                uup.updateProfileImage.InputStream.CopyTo(imgStream);
                u.profile_picture = Imgator.ImageToByte(new Bitmap(imgStream));
            }
            return u;
        }
        public static user operator +(user u, userUpdate uup)
        {
            uup.Role = u.type;

            if (String.IsNullOrEmpty(uup.updateName))
                uup.updateName = u.name;
            else
                u.name = uup.updateName;

            if (String.IsNullOrEmpty(uup.updateEmail))
                uup.updateEmail = u.email;
            else
                u.email = uup.updateEmail;

            if (String.IsNullOrEmpty(uup.updateMobile))
                uup.updateMobile = u.mobile;
            else
                u.mobile = uup.updateMobile;

            if (String.IsNullOrEmpty(uup.updatePassword))
            {
                uup.updatePassword = u.password;
                uup.confirmUpdatePassword = u.password;
                uup.Password = u.password;
                u.confirmPassword = u.password;
            }
            else if (uup.updatePassword == u.password)
            {
                uup.updatePassword = u.password;
                uup.confirmUpdatePassword = u.password;
                uup.Password = u.password;
                u.confirmPassword = u.password;
            }
            else
            {
                u.password = StringCipher.hashPassword(uup.updatePassword);
                uup.updatePassword = u.password;
                uup.confirmUpdatePassword = u.password;
                uup.Password = u.password;
                u.confirmPassword = u.password;
            }

            if (uup.updateProfileImage == null)
                uup.updateProfilePicture = u.profile_picture;
            else
            {
                MemoryStream imgStream = new MemoryStream();
                uup.updateProfileImage.InputStream.CopyTo(imgStream);
                u.profile_picture = Imgator.ImageToByte(new Bitmap(imgStream));
            }
            return u;
        }
    }
}
