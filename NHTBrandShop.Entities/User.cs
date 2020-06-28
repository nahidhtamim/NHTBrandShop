using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Entities
{
    [Table("Table_Users")]
    public class User
    {
        public int UserID { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Maximum Length Should be 50 Characters")]
        public string UserName { get; set; }
        public string Password { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string BillingAddress { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
