using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace BOL
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            GamesJournalEntities db = new GamesJournalEntities();
            string userEmailValue = Convert.ToString(value);
            int count = db.user.Where(x => x.email == userEmailValue).ToList().Count();
            if (count != 0)
                return new ValidationResult("User Already Exist With This Email ID");
            return ValidationResult.Success;
        }
    }
    public class UniqueUsernameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            GamesJournalEntities db = new GamesJournalEntities();
            string userNameValue = Convert.ToString(value);
            int count = db.user.Where(x => x.username == userNameValue).ToList().Count();
            if (count != 0)
                return new ValidationResult("User Already Exist With This Username ID");
            return ValidationResult.Success;
        }
    }

    public class userValidation
    {
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress]
        [UniqueEmail]
        public string email { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        [StringLength(100)]
        [RegularExpression(@"^(([a-zA-Z]{2,}[ ])+([a-zA-Z]{2,})+)+$", ErrorMessage = "User Name Is Not Valid Full Name!")]
        [Display(Name = "Full Name")]
        public string name { get; set; }

        [UniqueUsername]
        [Required]
        public string username { get; set; }

        [Required(ErrorMessage="Mobile Number Is Required")]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Entered mobile format is not valid.")]
        public string mobile { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Is Required")]
        [MembershipPassword(
        MinRequiredNonAlphanumericCharacters = 1,
        MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
        ErrorMessage = "Your password must be 6 characters long contains at least one digit and one symbol (!, @, #, etc).",
        MinRequiredPasswordLength = 6)]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Confirmation Is Required")]
        [Compare("password")]
        public string confirmPassword { get; set; }
    }

    [MetadataType(typeof(userValidation))]
    public partial class user
    {
        public string confirmPassword { get; set; }
        public HttpPostedFileBase ProfileImage { get; set; }
    }
}
