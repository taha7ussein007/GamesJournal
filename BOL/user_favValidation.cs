using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class user_favValidation
    {
        [Required]
        [Index("user_fav_user_id_2", 1, IsUnique = true)]
        public int user_id { get; set; }
        [Required]
        [Index("user_fav_user_id_2", 2, IsUnique = true)]
        public int art_id { get; set; }
    }

    [MetadataType(typeof(user_favValidation))]
    public partial class user_fav
    {
    }
}
