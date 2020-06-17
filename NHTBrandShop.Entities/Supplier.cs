using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Entities
{
    [Table("Table_Suppliers")]
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        [Required]
        [MaxLength(100)]
        public string SupplierName { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
