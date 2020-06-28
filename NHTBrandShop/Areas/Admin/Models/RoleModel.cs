using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NHTBrandShop.Areas.Admin.Models
{
    public class RoleListingModel
    {
        public IEnumerable<Role> Roles { get; set; }

    }

    public class RoleActionModel
    {
        public int RoleID { get; set; }
        [Required]
        public string RoleName { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}