using NHTBrandShop.DB;
using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Services
{
    public class MainMenuServices
    {
        public IEnumerable<MainMenu> GetAllMainMenus()
        {
            var context = new BrandShopContext();

            return context.MainMenus.ToList();

        }

        public IEnumerable<MainMenu> SearchMainMenus(string SearchTerm)
        {
            var context = new BrandShopContext();

            var mainMenu = context.MainMenus.AsQueryable();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                mainMenu = (from u in context.MainMenus where u.MainMenuName.Contains(SearchTerm) || u.Description.Contains(SearchTerm) select u);
            }

            return mainMenu.ToList();


        }

        public MainMenu GetMainMenuByID(int ID)
        {
            using (var context = new BrandShopContext())
            {
                return context.MainMenus.Find(ID);
            }
            
        }

        public bool SaveMenu(MainMenu mainMenu)
        {
            var context = new BrandShopContext();
            
            context.MainMenus.Add(mainMenu);

            return context.SaveChanges() > 0;
        }

        public bool UpdateMenu(MainMenu mainMenu)
        {
            var context = new BrandShopContext();
            
            context.Entry(mainMenu).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;

        }

        public bool DeleteMenu(MainMenu mainMenu)
        {
            var context = new BrandShopContext();
            
            context.Entry(mainMenu).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }

    }
}
