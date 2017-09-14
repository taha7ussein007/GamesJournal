using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class article_typeValidation
    {
        [Required]
        public string category { get; set; }
    }

    [MetadataType(typeof(article_typeValidation))]
    public partial class article_type
    {
    }
}
