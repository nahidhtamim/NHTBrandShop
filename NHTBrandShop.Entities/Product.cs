using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Entities
{
    [Table("Table_Products")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [ForeignKey("MainMenu")]
        public int MainMenuID { get; set; }
        public virtual MainMenu MainMenu { get; set; }

        [ForeignKey("SubMenu")]
        public int? SubMenuID { get; set; }
        public virtual SubMenu SubMenu { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProductCode { get; set; }

        public decimal BuyingPrice { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string Color { get; set; }
        public string Config { get; set; }
        public string Description { get; set; }
        
        [ForeignKey("Suppliers")]
        public int SupplierID { get; set; }
        public virtual Supplier Suppliers { get; set; }

        [ForeignKey("Tags")]
        public int TagID { get; set; }
        public virtual Tag Tags { get; set; }

        public bool ProductStatus { get; set; }
        public DateTime UpdatedAt { get; set; }


        public List<ProductPicture> ProductPictures { get; set; }
    }
}
