using NHTBrandShop.DB;
using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Services
{
    public class SupplierServices
    {
        public IEnumerable<Supplier> GetAllSuppliers()
        {
            var context = new BrandShopContext();

            return context.Suppliers.ToList();
        }

        public Supplier GetSupplierByID(int ID)
        {
            using (var context = new BrandShopContext())
            {
                return context.Suppliers.Find(ID);
            }
        }

        public bool SaveSupplier(Supplier supplier)
        {
            var context = new BrandShopContext();

            context.Suppliers.Add(supplier);

            return context.SaveChanges() > 0;
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            var context = new BrandShopContext();

            context.Entry(supplier).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteSupplier(Supplier supplier)
        {
            var context = new BrandShopContext();

            context.Entry(supplier).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }

    }
}
