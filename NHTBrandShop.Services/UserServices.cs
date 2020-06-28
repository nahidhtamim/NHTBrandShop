using NHTBrandShop.DB;
using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Services
{
    public class UserServices
    {
        public IEnumerable<User> GetAllUsers()
        {
            var context = new BrandShopContext();

            return context.Users.ToList();

        }

        //public IEnumerable<User> SearchUsers(string SearchTerm)
        //{
        //    var context = new BrandShopContext();

        //    var user = context.Users.AsQueryable();

        //    if (!string.IsNullOrEmpty(SearchTerm))
        //    {
        //        user = (from u in context.Users where u.UserName.Contains(SearchTerm) || u.Description.Contains(SearchTerm) select u);
        //    }

        //    return user.ToList();

        //}

        public User GetUserByID(int ID)
        {
            using (var context = new BrandShopContext())
            {
                return context.Users.Find(ID);
            }

        }

        public bool SaveUser(User user)
        {
            var context = new BrandShopContext();

            context.Users.Add(user);

            return context.SaveChanges() > 0;
        }

        public bool UpdateUser(User user)
        {
            var context = new BrandShopContext();

            context.Entry(user).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;

        }

        public bool DeleteUser(User user)
        {
            var context = new BrandShopContext();

            context.Entry(user).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
