using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class commentValidation
    {
        [Required]
        [Display(Name = "Comment")]
        public string content { get; set; }
    }

    [MetadataType(typeof(commentValidation))]
    public partial class comment
    {
    }
}
