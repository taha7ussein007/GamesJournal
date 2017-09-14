using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class feedbackValidation
    {
        [Required]
        public string content { get; set; }
    }

    [MetadataType(typeof(feedbackValidation))]
    public partial class feedback
    {
    }
}
