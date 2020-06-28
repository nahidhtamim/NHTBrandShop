using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Entities
{
    [Table("Table_SubMenuPictures")]
    public class SubMenuPicture
    {
        [Key]
        public int SubMenuPictureID { get; set; }

        public int SubMenuID { get; set; }

        public int PictureID { get; set; }

        public virtual Picture Picture { get; set; }
    }
}
