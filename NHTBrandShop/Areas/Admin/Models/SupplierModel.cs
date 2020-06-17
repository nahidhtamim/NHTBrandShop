using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NHTBrandShop.Areas.Admin.Models
{
    public class SupplierListingModel
    {
        public IEnumerable<Supplier> Suppliers { get; set; }
    }

    public class SupplierActionModel
    {
        public int SupplierID { get; set; }
        [Required]
        public string SupplierName { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}