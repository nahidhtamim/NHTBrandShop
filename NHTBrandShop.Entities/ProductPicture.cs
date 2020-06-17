using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Entities
{
    public class ProductPicture
    {
        [Key]
        public int ProductPictureID { get; set; }

        public int ProductID { get; set; }

        public int PictureID { get; set; }

        public virtual Picture Picture { get; set; }

    }
}
