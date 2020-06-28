using NHTBrandShop.DB;
using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Services
{
    public class BrandServices
    {
        public IEnumerable<Brand> GetAllBrands()
        {
            var context = new BrandShopContext();

            return context.Brands.ToList();

        }


        public Brand GetBrandByID(int ID)
        {
            using (var context = new BrandShopContext())
            {
                return context.Brands.Find(ID);
            }

        }

        public bool SaveBrand(Brand brand)
        {
            var context = new BrandShopContext();

            context.Brands.Add(brand);

            return context.SaveChanges() > 0;
        }

        public bool UpdateBrand(Brand brand)
        {
            var context = new BrandShopContext();

            context.Entry(brand).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;

        }

        public bool DeleteBrand(Brand brand)
        {
            var context = new BrandShopContext();

            context.Entry(brand).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
