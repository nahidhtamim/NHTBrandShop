using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NHTBrandShop.Areas.Admin.Models
{
    public class TagListingModel
    {
        public IEnumerable<Tag> Tags { get; set; }
    }

    public class TagActionModel
    {
        public int TagID { get; set; }
        [Required]
        public string TagTitle { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}