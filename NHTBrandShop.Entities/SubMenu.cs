using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Entities
{
    [Table("Table_SubMenu")]
    public class SubMenu
    {
        [Key]
        public int SubMenuID { get; set; }
        [Required]
        [ForeignKey("MainMenu")]
        public int MainMenuID { get; set; }
        public virtual MainMenu MainMenu { get; set; }
        [Required]
        [MaxLength(50)]
        public string SubMenuName { get; set; }
        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime UpdatedAt { get; set; }


        public List<SubMenuPicture> SubMenuPictures { get; set; }
    }
}
