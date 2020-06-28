using NHTBrandShop.DB;
using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Services
{
    public class SubMenuServices
    {
        public IEnumerable<SubMenu> GetAllSubMenus()
        {
            var context = new BrandShopContext();

            return context.SubMenus.ToList();
        }

        public IEnumerable<SubMenu> SearchSubMenus(string SearchTerm)
        {
            var context = new BrandShopContext();
            
            var subMenus = context.SubMenus.AsQueryable();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                subMenus = (from s in context.SubMenus where s.SubMenuName.Contains(SearchTerm) || s.Description.Contains(SearchTerm) select s);
            }
            return subMenus.ToList();
        }

        public IEnumerable<SubMenu> GetSubMenuByMainMenu(int MainMenuID)
        {
            var context = new BrandShopContext();
            
            return context.SubMenus.Where(x => x.MainMenuID == MainMenuID).ToList();

        }

        public SubMenu GetSubMenuByID(int ID)
        {
            var context = new BrandShopContext();
            
            return context.SubMenus.Find(ID);
            
        }

        public bool SaveSubMenu(SubMenu subMenu)
        {
            var context = new BrandShopContext();

            context.SubMenus.Add(subMenu);

            return context.SaveChanges() > 0;

        }

        public bool UpdateSubMenu(SubMenu subMenu)
        {
            var context = new BrandShopContext();

            var exitingSubMenu = context.SubMenus.Find(subMenu.SubMenuID);

            context.SubMenuPictures.RemoveRange(exitingSubMenu.SubMenuPictures);

            context.Entry(exitingSubMenu).CurrentValues.SetValues(subMenu);

            context.SubMenuPictures.AddRange(subMenu.SubMenuPictures);

            //context.Entry(subMenu).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteSubMenu(SubMenu subMenu)
        {
            var context = new BrandShopContext();
            
            context.Entry(subMenu).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;

        }


        public List<SubMenuPicture> GetPictureBySubMneID(int subMenuID)
        {
            var context = new BrandShopContext();

            return context.SubMenus.Find(subMenuID).SubMenuPictures.ToList();

        }
    }
}
