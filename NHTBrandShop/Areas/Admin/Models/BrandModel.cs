using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NHTBrandShop.Areas.Admin.Models
{
    public class BrandListingModel
    {
        public IEnumerable<Brand> Brands { get; set; }

    }

    public class BrandActionModel
    {
        public int BrandID { get; set; }
        [Required]
        public string BrandName { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}