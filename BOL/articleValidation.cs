using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class articleValidation
    {
        [Required]
        [Display(Name="Title")]
        [StringLength(100)]
        [RegularExpression(@"^(([a-zA-Z]{2,}[ ])+([a-zA-Z]{2,})+)+$", 
            ErrorMessage = "Article Title Should Be Like A Full Name :D")]
        public string title { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string content { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int category { get; set; }

        [Required]
        [Display(Name = "Author")]
        public int author { get; set; }

        [Display(Name = "Date Created")]
        public System.DateTime timestamp { get; set; }
    }


    [MetadataType(typeof(articleValidation))]
    public partial class article
    {
        /// <summary>
        /// Static List Of User IDs Whom Rated This Article.
        /// </summary>
        public static List<int> ratedByLst { get; set; }
    }
}
