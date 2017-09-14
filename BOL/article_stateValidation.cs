using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class article_stateValidation
    {
        [Required]
        public string state { get; set; }
    }

    [MetadataType(typeof(article_stateValidation))]
    public partial class article_state
    {
    }
}
