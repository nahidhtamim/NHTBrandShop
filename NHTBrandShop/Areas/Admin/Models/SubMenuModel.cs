using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NHTBrandShop.Areas.Admin.Models
{
    public class SubMenuListingModel
    {
        public IEnumerable<SubMenu> subMenus { get; set; }
        public string SearchTerm { get; set; }
        public IEnumerable<MainMenu> MainMenus { get; set; }
        public int? MainMenuID { get; set; }

    }

    public class SubMenuActionModel
    {
        public int SubMenuID { get; set; }
        [Required]
        public int MainMenuID { get; set; }
        public MainMenu MainMenu { get; set; }
        [Required]
        public string SubMenuName { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string SubMenuPictures { get; set; }

        public IEnumerable<MainMenu> MainMenus { get; set; }

    }
}