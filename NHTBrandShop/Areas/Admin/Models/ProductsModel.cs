using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NHTBrandShop.Areas.Admin.Models
{
    public class ProductsListingModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string SearchTerm { get; set; }

        public IEnumerable<SubMenu> SubMenus { get; set; }
        public int? SubMenuID { get; set; }
        
        public IEnumerable<MainMenu> MainMenus { get; set; }
        public int? MainMenuID { get; set; }

        public IEnumerable<Brand> Brands { get; set; }
        public int? BrandID { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
        public int? TagID { get; set; }

        public IEnumerable<Supplier> Suppliers { get; set; }
        public int? SupplierID { get; set; }

    }

    public class ProductsActionModel
    {
        public int ProductID { get; set; }

        [Required]
        public int MainMenuID { get; set; }
        public MainMenu MainMenu { get; set; }

        public int? SubMenuID { get; set; }
        public SubMenu SubMenu { get; set; }

        public int BrandID { get; set; }
        public Brand Brand { get; set; }

        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductCode { get; set; }

        public decimal BuyingPrice { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string Color { get; set; }
        public string Config { get; set; }

        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsFeatured { get; set; }

        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }

        public int TagID { get; set; }
        public Tag Tag { get; set; }


        public DateTime UpdatedAt { get; set; }

        public IEnumerable<SubMenu> SubMenus { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<MainMenu> MainMenus { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
        public IEnumerable<Tag> Tags { get; set; }

    }
}