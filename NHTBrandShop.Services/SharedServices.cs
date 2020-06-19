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
        public int SavePicture(Picture picture)
        {
            var context = new BrandShopContext();

            context.Pictures.Add(picture);

            context.SaveChanges();

            return picture.PictureID;
        }
    }
}
