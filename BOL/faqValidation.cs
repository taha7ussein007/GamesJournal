using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class UniqueQAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            GamesJournalEntities db = new GamesJournalEntities();
            //string QValue = Convert.ToString(value);
            //int count = db.faqs.Where(x => x.question == QValue).ToList().Count();
            //if (count != 0)
            //    return new ValidationResult("This Question Already Exists Before!");
            return ValidationResult.Success;
        }
    }
    public class faqValidation
    {
        [Required]
        [UniqueQ]
        [Display(Name="Question")]
        public string question { get; set; }
    }

    [MetadataType(typeof(faqValidation))]
    public partial class faq
    {
    }
}
