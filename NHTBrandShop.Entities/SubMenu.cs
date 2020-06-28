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
        [Required/*(ErrorMessage = "Main Menu must be selected")*/]
        [ForeignKey("MainMenu")]
        public int MainMenuID { get; set; }
        public virtual MainMenu MainMenu { get; set; }
        [Required/*(ErrorMessage = "Sub Menu Name is Required")*/]
        [MaxLength(50, ErrorMessage ="Maximum Length Should be 50 Characters")]
        public string SubMenuName { get; set; }
        public string Description { get; set; }


        public DateTime UpdatedAt { get; set; }


        public virtual List<SubMenuPicture> SubMenuPictures { get; set; }
    }
}
