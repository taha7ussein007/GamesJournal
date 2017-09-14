using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class user_typeValidation
    {
        [Required]
        public string type { get; set; }
    }

    [MetadataType(typeof(user_typeValidation))]
    public partial class user_type
    {
    }
}
