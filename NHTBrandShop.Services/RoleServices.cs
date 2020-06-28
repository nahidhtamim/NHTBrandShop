using NHTBrandShop.DB;
using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Services
{
    public class RoleServices
    {
        public IEnumerable<Role> GetAllRoles()
        {
            var context = new BrandShopContext();

            return context.Roles.ToList();

        }


        public Role GetRoleByID(int ID)
        {
            var context = new BrandShopContext();
            
            return context.Roles.Find(ID);
            
        }

        public bool SaveRole(Role role)
        {
            var context = new BrandShopContext();

            context.Roles.Add(role);

            return context.SaveChanges() > 0;
        }

        public bool UpdateRole(Role role)
        {
            var context = new BrandShopContext();

            context.Entry(role).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;

        }

        public bool DeleteRole(Role role)
        {
            var context = new BrandShopContext();

            context.Entry(role).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }

    }
}
