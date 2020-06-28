using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NHTBrandShop.Areas.Admin.Models
{
    public class UserListingModel
    {
        public IEnumerable<User> Users { get; set; }
        public string SearchTerm { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public int? RoleID { get; set; }

    }

    public class UserActionModel
    {
        public int UserID { get; set; }

        [Required]
        public int RoleID { get; set; }
        public Role Role { get; set; }

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


        public IEnumerable<Role> Roles { get; set; }
    }
}