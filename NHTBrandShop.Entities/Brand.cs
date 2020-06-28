using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Entities
{
    [Table("Table_Brands")]
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }
        [Required]
        public string BrandName { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
