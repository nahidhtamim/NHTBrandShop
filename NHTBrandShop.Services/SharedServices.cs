using NHTBrandShop.DB;
using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Services
{
    public class SharedServices
    {
        public bool SavePicture(Picture pictures)
        {
            var context = new BrandShopContext();

            context.Pictures.Add(pictures);

            return context.SaveChanges() > 0;
        }
        public IEnumerable<Picture> GetPictureByIDs(List<int> pictureIDs)
        {
            var context = new BrandShopContext();

            return pictureIDs.Select(x => context.Pictures.Find(x)).ToList();
        }
    }
}
