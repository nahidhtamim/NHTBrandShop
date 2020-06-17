using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Entities
{
    [Table("Table_MainMenu")]
    public class MainMenu
    {
        [Key]
        public int MainMenuID { get; set; }
        [Required]
        [MaxLength(50)]
        public string MainMenuName { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
