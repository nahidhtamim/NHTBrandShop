using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Entities
{
    [Table("Table_Tags")]
    public class Tag
    {
        [Key]
        public int TagID { get; set; }
        [Required]
        [MaxLength(50)]
        public string TagTitle { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
