using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Entities
{
    [Table("Table_ProductPictures")]
    public class ProductPicture
    {
        [Key]
        public int ProductPictureID { get; set; }

        public int ProductID { get; set; }

        public int PictureID { get; set; }

        public virtual Picture Picture { get; set; }

    }
}
