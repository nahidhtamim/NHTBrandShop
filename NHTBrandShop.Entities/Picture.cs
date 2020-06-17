using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Entities
{
    [Table("Table_Pictures")]
    public class Picture
    {
        [Key]
        public int PictureID { get; set; }

        public string Url { get; set; }

    }
}
