using NHTBrandShop.DB;
using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Services
{
    public class ProductServices
    {
        public IEnumerable<Product> GetAllProducts()
        {
            var context = new BrandShopContext();

            return context.Products.ToList();
        }

        public IEnumerable<Product> GetProductByMainMenu(int MainMenuID)
        {
            var context = new BrandShopContext();

            return context.Products.Where(x => x.MainMenuID == MainMenuID).ToList();
        }

        public IEnumerable<Product> GetProductBySubMenu(int SubMenuID)
        {
            var context = new BrandShopContext();

            return context.Products.Where(x => x.SubMenuID == SubMenuID).ToList();
        }

        public IEnumerable<Product> GetProductByTag(int TagID)
        {
            var context = new BrandShopContext();

            return context.Products.Where(x => x.TagID == TagID).ToList();
        }

        public IEnumerable<Product> GetProductBySupplier(int SupplierID)
        {
            var context = new BrandShopContext();

            return context.Products.Where(x => x.SupplierID == SupplierID).ToList();
        }

        public Product GetProductByID(int ID)
        {
            using (var context = new BrandShopContext())
            {
                return context.Products.Find(ID);
            }
        }

        public bool SaveProduct(Product product)
        {
            var context = new BrandShopContext();

            context.Products.Add(product);

            return context.SaveChanges() > 0;
        }

        public bool UpdateProduct(Product product)
        {
            var context = new BrandShopContext();

            context.Entry(product).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteProduct(Product product)
        {
            var context = new BrandShopContext();

            context.Entry(product).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }

    }
}
