using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NHTBrandShop.Areas.Admin.Models
{
    public class MainMenuListingModel
    {
        public IEnumerable<MainMenu> MainMenus { get; set; }
        public string SearchTerm { get; set; }

    }

    public class MainMenuActionModel
    {
        public int MainMenuID { get; set; }
        [Required]
        public string MainMenuName { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}