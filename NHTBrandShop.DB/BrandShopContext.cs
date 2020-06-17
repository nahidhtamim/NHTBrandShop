using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.DB
{
    public class BrandShopContext : DbContext
    {
        public BrandShopContext() : base("NHTBrandShopConnectionString")
        {
        }

        public DbSet<MainMenu> MainMenus { get; set; }

        public DbSet<SubMenu> SubMenus { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Picture> Pictures { get; set; }
    }
}
