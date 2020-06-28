using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Entities
{
    [Table("Table_Roles")]
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        [Required]
        public string RoleName { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
